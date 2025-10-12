namespace Project.CarParser.Application.Features.CarListings.Commands;

public record CreateCarListingCommand(CreateCarListingDTO CarListingDTO)
  : CreateEntityCommand<CreateCarListingDTO>(CarListingDTO);

internal class CreateCarListingCommandHandler(ICarListingUnitOfWork carListingUnitOfWork,
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
  : CreateEntityCommandHandler<CarListing, CreateCarListingDTO, CreateCarListingCommand>(carListingSpecification, mapper)
{
  readonly IMapper _mapper = mapper;

  public new async Task<Unit> Handle(CreateCarListingCommand request, CancellationToken cancellationToken)
  {
    var carListingFilter = BuildDuplicateCheckFilter(request.CreateDto);
    var carListingSpec = BuildSpecification(carListingFilter);
    await ValidateEntityDoesNotExistAsync(carListingSpec, cancellationToken);

    // Validate all dependencies exist
    await ValidateAllDependenciesExistAsync(request.CreateDto, cancellationToken);

    // Get all dependencies in parallel
    var dependencies = await GetDependenciesAsync(request.CreateDto, cancellationToken);

    // Create and persist the new entity
    var newEntity = CreateCarListingWithDependencies(request.CreateDto, dependencies);
    PersistNewEntity(newEntity);

    return Unit.Value;
  }

  async Task ValidateAllDependenciesExistAsync(CreateCarListingDTO dto, CancellationToken cancellationToken)
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

  async Task<Dependencies> GetDependenciesAsync(CreateCarListingDTO dto, CancellationToken cancellationToken)
  {
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

    return new Dependencies(placeRegionTask.Result,
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

  protected override async Task ValidateEntityDoesNotExistAsync(ISpecification<CarListing> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await carListingUnitOfWork.CarListings.AnyByQueryAsync(specification, cancellationToken);

    if (exists is true) throw new EntityAlreadyExists(typeof(CarListing), specification.ToString() ?? string.Empty);
  }

  protected override ISpecification<CarListing> BuildSpecification(Expression<Func<CarListing, bool>>? filterExpr)
  {
    var spec = carListingSpecification.Clone();

    if (filterExpr is not null) spec.AddFilter(filterExpr);

    return spec;
  }

  protected override void PersistNewEntity(CarListing entity)
  {
    carListingUnitOfWork.StartTransaction();
    carListingUnitOfWork.CarListings.InsertOne(entity);
    carListingUnitOfWork.Complete();
  }

  protected override Expression<Func<CarListing, bool>>? BuildDuplicateCheckFilter(CreateCarListingDTO createDto)
  {
    return BuildPropertyFilter<CarListing>(nameof(CarListing.Url), createDto.Url);
  }

  Expression<Func<T, bool>>? BuildIdFilter<T>(Guid id) where T : BaseEntity
  {
    return BuildPropertyFilter<T>(nameof(BaseEntity.Id), id.ToString());
  }

  Expression<Func<T, bool>>? BuildPropertyFilter<T>(string propertyName, string value)
  {
    return queryFilterParser.ParseFilters<T>(new RequestParameters
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

  static ISpecification<T> BuildGenericSpecification<T>(Expression<Func<T, bool>>? filter,
                                                        ISpecification<T> baseSpecification) where T : BaseEntity
  {
    var spec = baseSpecification.Clone();
    if (filter is not null) spec.AddFilter(filter);
    return spec;
  }

  CarListing CreateCarListingWithDependencies(CreateCarListingDTO dto,
                                              Dependencies dependencies)
  {
    var carListing = MapToEntity<CreateCarListingDTO, CarListing>(dto);

    carListing.PlaceRegion = dependencies.PlaceRegion;
    carListing.PlaceCity = dependencies.PlaceCity;
    carListing.TransmissionType = dependencies.TransmissionType;
    carListing.EngineType = dependencies.EngineType;
    carListing.BodyType = dependencies.BodyType;

    return carListing;
  }

  TOut MapToEntity<TInput, TOut>(TInput dto) => _mapper.Map<TOut>(dto);

  private record Dependencies(PlaceRegion PlaceRegion,
                              PlaceCity PlaceCity,
                              TransmissionType TransmissionType,
                              EngineType EngineType,
                              BodyType BodyType);
}
