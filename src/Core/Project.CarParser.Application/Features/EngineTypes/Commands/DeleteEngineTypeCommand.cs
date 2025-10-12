namespace Project.CarParser.Application.Features.EngineTypes.Commands;

public record DeleteEngineTypeCommand(Guid Id) : DeleteEntityCommand(Id);

internal class DeleteEngineTypeCommandHandler(IEngineTypeUnitOfWork EngineTypeUnitOfWork,
                                              IEngineTypeSpecification specification,
                                              IQueryFilterParser queryFilterParser)
: DeleteEntityCommandHandler<EngineType, DeleteEngineTypeCommand>(specification,
                                                                  queryFilterParser)
{
  protected override void DeleteEntity(EngineType entity)
  {
    EngineTypeUnitOfWork.EngineTypies.DeleteOne(entity);
    EngineTypeUnitOfWork.Complete();
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<EngineType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await EngineTypeUnitOfWork.EngineTypies.AnyByQueryAsync(specification,
                                                                          cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(EngineType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<EngineType> FetchEntityAsync(ISpecification<EngineType> specification,
                                                             CancellationToken cancellationToken)
    => await EngineTypeUnitOfWork.EngineTypies.GetOneShortAsync(specification, cancellationToken);
}
