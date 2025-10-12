namespace Project.CarParser.Application.Features.CarListings.Commands;

public record DeleteCarListingCommand(Guid Id) : DeleteEntityCommand(Id);

internal class DeleteCarListingCommandHandler(ICarListingUnitOfWork carListingUnitOfWork,
                                              ICarListingSpecification specification,
                                              IQueryFilterParser queryFilterParser)
: DeleteEntityCommandHandler<CarListing, DeleteCarListingCommand>(specification,
                                                                  queryFilterParser)
{
  protected override void DeleteEntity(CarListing entity)
  {
    carListingUnitOfWork.CarListings.DeleteOne(entity);
    carListingUnitOfWork.Complete();
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
}
