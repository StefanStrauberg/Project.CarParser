namespace Project.CarParser.Application.Features.CarListings.Commands;

public record CreateBulkCarListingsCommand(IEnumerable<CreateCarListingDTO> CreateDtos)
  : CreateBulkEntitiesCommand<CreateCarListingDTO>(CreateDtos);

internal class CreateBulkCarListingsCommandHandler(ICarListingUnitOfWork carListingUnitOfWork,
                                                   IPlaceRegionUnitOfWork placeRegionUnitOfWork,
                                                   IPlaceCityUnitOfWork placeCityUnitOfWork,
                                                   ITransmissionTypeUnitOfWork transmissionTypeUnitOfWork,
                                                   IEngineTypeUnitOfWork engineTypeUnitOfWork,
                                                   IBodyTypeUnitOfWork bodyTypeUnitOfWork,
                                                   ICarListingSpecification carListingSpecification,
                                                   IPlaceRegionSpecification placeRegionSpecification,
                                                   IPlaceCitySpecification placeCitySpecification,
                                                   ITransmissionTypeSpecification transmissionTypeSpecification,
                                                   IEngineTypeSpecification engineTypeSpecification,
                                                   IBodyTypeSpecification bodyTypeSpecification,
                                                   IMapper mapper)
  : CreateBulkEntitiesCommandHandler<CarListing, CreateCarListingDTO, CreateBulkCarListingsCommand>(carListingSpecification, mapper)
{
  private HashSet<string> _existingUrls = [];

  public new async Task<Unit> Handle(CreateBulkCarListingsCommand request, CancellationToken cancellationToken)
  {
    var filter = BuildDuplicateCheckFilter(request.CreateDtos);
    var specification = BuildSpecification(filter);

    await ValidateEntitiesDoNotExistAsync(specification, cancellationToken);
    await ValidateAllDependenciesExistAsync(request.CreateDtos, cancellationToken);

    var newEntities = MapToEntities(request.CreateDtos);
    PersistNewEntities(newEntities);

    return Unit.Value;
  }

  protected override Expression<Func<CarListing, bool>>? BuildDuplicateCheckFilter(IEnumerable<CreateCarListingDTO> dtos)
  {
    var urls = dtos.Select(dto => dto.Url).ToHashSet();
    return listing => urls.Contains(listing.Url);
  }

  protected override async Task ValidateEntitiesDoNotExistAsync(ISpecification<CarListing> specification, CancellationToken cancellationToken)
  {
    var existingListings = await carListingUnitOfWork.CarListings.GetManyShortAsync(specification, cancellationToken);
    _existingUrls = [.. existingListings.Select(x => x.Url)];
  }

  protected override void PersistNewEntities(IEnumerable<CarListing> entities)
  {
    var newEntities = entities.Where(e => !_existingUrls.Contains(e.Url)).ToList();
    if (newEntities.Count == 0) return;

    carListingUnitOfWork.StartTransaction();
    carListingUnitOfWork.CarListings.InsertMany(newEntities);
    carListingUnitOfWork.Complete();
  }

  private async Task ValidateAllDependenciesExistAsync(IEnumerable<CreateCarListingDTO> dtos, CancellationToken cancellationToken)
  {
    var regionIds = dtos.Select(x => x.PlaceRegionId).Where(id => id != Guid.Empty).Distinct().ToList();
    var cityIds = dtos.Select(x => x.PlaceCityId).Distinct().ToList();
    var transmissionIds = dtos.Select(x => x.TransmissionTypeId).Distinct().ToList();
    var engineIds = dtos.Select(x => x.EngineTypeId).Distinct().ToList();
    var bodyIds = dtos.Select(x => x.BodyTypeId).Distinct().ToList();

    var regionTask = GetExistingIdsAsync(placeRegionUnitOfWork.PlaceRegions, placeRegionSpecification, regionIds, cancellationToken);
    var cityTask = GetExistingIdsAsync(placeCityUnitOfWork.PlaceCities, placeCitySpecification, cityIds, cancellationToken);
    var transmissionTask = GetExistingIdsAsync(transmissionTypeUnitOfWork.TransmissionTypies, transmissionTypeSpecification, transmissionIds, cancellationToken);
    var engineTask = GetExistingIdsAsync(engineTypeUnitOfWork.EngineTypes, engineTypeSpecification, engineIds, cancellationToken);
    var bodyTask = GetExistingIdsAsync(bodyTypeUnitOfWork.BodyTypes, bodyTypeSpecification, bodyIds, cancellationToken);

    await Task.WhenAll(regionTask, cityTask, transmissionTask, engineTask, bodyTask);

    ThrowIfMissing(regionIds, regionTask.Result, typeof(PlaceRegion));
    ThrowIfMissing(cityIds, cityTask.Result, typeof(PlaceCity));
    ThrowIfMissing(transmissionIds, transmissionTask.Result, typeof(TransmissionType));
    ThrowIfMissing(engineIds, engineTask.Result, typeof(EngineType));
    ThrowIfMissing(bodyIds, bodyTask.Result, typeof(BodyType));
  }

  private static async Task<HashSet<Guid>> GetExistingIdsAsync<T>(IRepository<T> repository,
                                                                  ISpecification<T> baseSpec,
                                                                  IEnumerable<Guid> ids,
                                                                  CancellationToken cancellationToken)
    where T : BaseEntity
  {
    if (!ids.Any()) return [];

    var spec = baseSpec.Clone().AddFilter(x => ids.Contains(x.Id));
    var entities = await repository.GetManyShortAsync(spec, cancellationToken);
    return [.. entities.Select(x => x.Id)];
  }

  private static void ThrowIfMissing(IEnumerable<Guid> expected, HashSet<Guid> actual, Type entityType)
  {
    var missing = expected.Except(actual).ToList();

    if (missing.Count > 0)
    {
      var message = $"Missing: {string.Join(", ", missing)}";
      throw new EntityNotFoundException(entityType, message);
    }
  }
}
