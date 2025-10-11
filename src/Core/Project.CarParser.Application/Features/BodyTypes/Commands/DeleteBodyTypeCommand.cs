namespace Project.CarParser.Application.Features.BodyTypes.Commands;

public record DeleteBodyTypeCommand(Guid Id) : DeleteEntityCommand(Id);

internal class DeleteBodyTypeCommandHandler(IBodyTypeUnitOfWork bodyTypeUnitOfWork,
                                            IBodyTypeSpecification specification,
                                            IQueryFilterParser queryFilterParser)
: DeleteEntityCommandHandler<BodyType, DeleteBodyTypeCommand>(specification,
                                                              queryFilterParser)
{
  protected override void DeleteEntity(BodyType entity)
  {
    bodyTypeUnitOfWork.BodyTypies.DeleteOne(entity);
    bodyTypeUnitOfWork.Complete();
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<BodyType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await bodyTypeUnitOfWork.BodyTypies.AnyByQueryAsync(specification,
                                                                      cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(BodyType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<BodyType> FetchEntityAsync(ISpecification<BodyType> specification,
                                                           CancellationToken cancellationToken)
    => await bodyTypeUnitOfWork.BodyTypies.GetOneShortAsync(specification, cancellationToken);
}
