namespace Project.CarParser.Application.Features.CarListings.Commands;

public record UpdateCarListingCommand(UpdateCarListingDTO UpdateCarListingDTO)
  : UpdateEntityCommand<CarListing, UpdateCarListingDTO>(UpdateCarListingDTO.Id, UpdateCarListingDTO);

internal class UpdateCarListingCommandHandler(ICarListingUnitOfWork carListingUnitOfWork,
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
                                              IQueryFilterParser queryFilterParser,
                                              IMapper mapper)
  : UpdateEntityCommandHandler<CarListing, UpdateCarListingDTO, UpdateCarListingCommand>(carListingSpecification,
                                                                                         queryFilterParser,
                                                                                         mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;
  readonly IMapper _mapper = mapper;

  public new async Task<Unit> Handle(UpdateCarListingCommand request, CancellationToken cancellationToken)
  {
    var specification = BuildSpecification(request.EntityId);
    await EnsureEntityExistAsync(specification, cancellationToken);

    // Validate all dependencies exist
    await ValidateAllDependenciesExistAsync(request.UpdateCarListingDTO, cancellationToken);

    // Get all dependencies in parallel
    var dependencies = await GetDependenciesAsync(request.UpdateCarListingDTO, cancellationToken);

    // Update and persist the new entity
    UpdateCarListingWithDependencies(request.UpdateCarListingDTO, dependencies.CarListing);
    UpdateEntity(dependencies.CarListing);

    return Unit.Value;
  }

  async Task ValidateAllDependenciesExistAsync(UpdateCarListingDTO dto, CancellationToken cancellationToken)
  {
    var validationTasks = new[]
    {
      ValidateDependencyExistsAsync(placeRegionUnitOfWork.PlaceRegions,
                                    BuildIdFilter<PlaceRegion>(dto.PlaceRegionId)!,
                                    placeRegionSpecification,
                                    cancellationToken),

      ValidateDependencyExistsAsync(placeCityUnitOfWork.PlaceCities,
                                    BuildIdFilter<PlaceCity>(dto.PlaceCityId)!,
                                    placeCitySpecification,
                                    cancellationToken),

      ValidateDependencyExistsAsync(transmissionTypeUnitOfWork.TransmissionTypies,
                                    BuildIdFilter<TransmissionType>(dto.TransmissionTypeId)!,
                                    transmissionTypeSpecification,
                                    cancellationToken),

      ValidateDependencyExistsAsync(engineTypeUnitOfWork.EngineTypes,
                                    BuildIdFilter<EngineType>(dto.EngineTypeId)!,
                                    engineTypeSpecification,
                                    cancellationToken),

      ValidateDependencyExistsAsync(bodyTypeUnitOfWork.BodyTypes,
                                    BuildIdFilter<BodyType>(dto.BodyTypeId)!,
                                    bodyTypeSpecification,
                                    cancellationToken)
    };

    await Task.WhenAll(validationTasks);
  }

  static async Task ValidateDependencyExistsAsync<T>(IRepository<T> repository,
                                                     Expression<Func<T, bool>> filter,
                                                     ISpecification<T> specification,
                                                     CancellationToken cancellationToken)
    where T : BaseEntity
  {
    var spec = BuildGenericSpecification(filter, specification);
    bool exists = await repository.AnyByQueryAsync(spec, cancellationToken);

    if (!exists) throw new EntityNotFoundException(typeof(T), spec.ToString() ?? string.Empty);
  }

  static ISpecification<T> BuildGenericSpecification<T>(Expression<Func<T, bool>>? filter,
                                                        ISpecification<T> baseSpecification) where T : BaseEntity
  {
    var spec = baseSpecification.Clone();
    if (filter is not null) spec.AddFilter(filter);
    return spec;
  }

  async Task<Dependencies> GetDependenciesAsync(UpdateCarListingDTO dto, CancellationToken cancellationToken)
  {
    var carListing = GetDependencyAsync(carListingUnitOfWork.CarListings,
                                        BuildIdFilter<CarListing>(dto.Id)!,
                                        carListingSpecification,
                                        cancellationToken);

    var placeRegionTask = GetDependencyAsync(placeRegionUnitOfWork.PlaceRegions,
                                             BuildIdFilter<PlaceRegion>(dto.PlaceRegionId)!,
                                             placeRegionSpecification,
                                             cancellationToken);

    var placeCityTask = GetDependencyAsync(placeCityUnitOfWork.PlaceCities,
                                           BuildIdFilter<PlaceCity>(dto.PlaceCityId)!,
                                           placeCitySpecification,
                                           cancellationToken);

    var transmissionTypeTask = GetDependencyAsync(transmissionTypeUnitOfWork.TransmissionTypies,
                                                  BuildIdFilter<TransmissionType>(dto.TransmissionTypeId)!,
                                                  transmissionTypeSpecification,
                                                  cancellationToken);

    var engineTypeTask = GetDependencyAsync(engineTypeUnitOfWork.EngineTypes,
                                            BuildIdFilter<EngineType>(dto.EngineTypeId)!,
                                            engineTypeSpecification,
                                            cancellationToken);

    var bodyTypeTask = GetDependencyAsync(bodyTypeUnitOfWork.BodyTypes,
                                          BuildIdFilter<BodyType>(dto.BodyTypeId)!,
                                          bodyTypeSpecification,
                                          cancellationToken);

    await Task.WhenAll(placeRegionTask, placeCityTask, transmissionTypeTask, engineTypeTask, bodyTypeTask);

    return new Dependencies(carListing.Result,
                            placeRegionTask.Result,
                            placeCityTask.Result,
                            transmissionTypeTask.Result,
                            engineTypeTask.Result,
                            bodyTypeTask.Result);
  }

  static async Task<T> GetDependencyAsync<T>(IRepository<T> repository,
                                             Expression<Func<T, bool>> filter,
                                             ISpecification<T> specification,
                                             CancellationToken cancellationToken)
    where T : BaseEntity
  {
    var spec = BuildGenericSpecification(filter, specification);
    return await repository.GetOneShortAsync(spec, cancellationToken);
  }

  private record Dependencies(CarListing CarListing,
                              PlaceRegion PlaceRegion,
                              PlaceCity PlaceCity,
                              TransmissionType TransmissionType,
                              EngineType EngineType,
                              BodyType BodyType);

  Expression<Func<T, bool>>? BuildIdFilter<T>(Guid id) where T : BaseEntity
  {
    return BuildPropertyFilter<T>(nameof(BaseEntity.Id), id.ToString());
  }

  void UpdateCarListingWithDependencies(UpdateCarListingDTO dto, CarListing carListing)
    => MapToDto(dto, carListing);

  Expression<Func<T, bool>>? BuildPropertyFilter<T>(string propertyName, string value)
  {
    return _queryFilterParser.ParseFilters<T>(new RequestParameters
    {
      Filters =
      [
        new()
        {
          PropertyPath = propertyName,
          Operator = FilterOperator.Equals,
          Value = value
        }
      ]
    }.Filters);
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<CarListing> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await carListingUnitOfWork.CarListings.AnyByQueryAsync(specification,
                                                                         cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(CarListing), specification.ToString() ?? string.Empty);
  }

  protected override async Task<CarListing> FetchEntityAsync(ISpecification<CarListing> specification,
                                                             CancellationToken cancellationToken)
    => await carListingUnitOfWork.CarListings.GetOneShortAsync(specification, cancellationToken);

  protected override void UpdateEntity(CarListing entity)
  {
    carListingUnitOfWork.CarListings.ReplaceOne(entity);
    carListingUnitOfWork.Complete();
  }
}
