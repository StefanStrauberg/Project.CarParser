namespace Project.CarParser.Application.Features.TransmissionTypes.Commands;

public record DeleteTransmissionTypeCommand(Guid Id) : DeleteEntityCommand(Id);

internal class DeleteTransmissionTypeCommandHandler(ITransmissionTypeUnitOfWork transmissionTypeUnitOfWork,
                                                    ITransmissionTypeSpecification specification,
                                                    IQueryFilterParser queryFilterParser)
: DeleteEntityCommandHandler<TransmissionType, DeleteTransmissionTypeCommand>(specification,
                                                                              queryFilterParser)
{
  protected override void DeleteEntity(TransmissionType entity)
  {
    transmissionTypeUnitOfWork.TransmissionTypies.DeleteOne(entity);
    transmissionTypeUnitOfWork.Complete();
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<TransmissionType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await transmissionTypeUnitOfWork.TransmissionTypies.AnyByQueryAsync(specification,
                                                                                      cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(TransmissionType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<TransmissionType> FetchEntityAsync(ISpecification<TransmissionType> specification,
                                                                   CancellationToken cancellationToken)
    => await transmissionTypeUnitOfWork.TransmissionTypies.GetOneShortAsync(specification, cancellationToken);
}
