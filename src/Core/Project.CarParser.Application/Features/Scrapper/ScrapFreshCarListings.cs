namespace Project.CarParser.Application.Features.Scrapper;

public record ScrapFreshCarListingsCommand : ICommand<Unit>;

internal class ScrapFreshCarListingsCommandHandler(ICarListingScraper scrapper,
                                                   ICarListingUnitOfWork carListingUnitOfWork,
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
  : ICommandHandler<ScrapFreshCarListingsCommand, Unit>
{
  public async Task<Unit> Handle(ScrapFreshCarListingsCommand request, CancellationToken cancellationToken)
  {
    var freshRawCarListings = await scrapper.GetFreshRawCarListingsAsync(cancellationToken);
    var referenceDataLoader = new ReferenceDataLoader(transmissionTypeUnitOfWork,
                                                      engineTypeUnitOfWork,
                                                      bodyTypeUnitOfWork,
                                                      placeCityUnitOfWork,
                                                      placeRegionUnitOfWork);
    var references = await referenceDataLoader.LoadAsync(cancellationToken);
    var createDtos = RawCarListingMapper.Map(freshRawCarListings, references);
    var command = new CreateBulkCarListingsCommand(createDtos);
    var handler = new CreateBulkCarListingsCommandHandler(carListingUnitOfWork,
                                                          placeRegionUnitOfWork,
                                                          placeCityUnitOfWork,
                                                          transmissionTypeUnitOfWork,
                                                          engineTypeUnitOfWork,
                                                          bodyTypeUnitOfWork,
                                                          carListingSpecification,
                                                          placeRegionSpecification,
                                                          placeCitySpecification,
                                                          transmissionTypeSpecification,
                                                          engineTypeSpecification,
                                                          bodyTypeSpecification,
                                                          mapper);
    await handler.Handle(command, cancellationToken);
    return Unit.Value;
  }
}
