namespace Project.CarParser.Application.Features.TransmissionTypes.Commands;

public record UpdateTransmissionTypeCommand(UpdateTransmissionTypeDTO UpdateTransmissionTypeDTO)
  : UpdateEntityCommand<TransmissionType, UpdateTransmissionTypeDTO>(UpdateTransmissionTypeDTO.Id, UpdateTransmissionTypeDTO);

internal class UpdateTransmissionTypeCommandHandler(ITransmissionTypeUnitOfWork transmissionTypeUnitOfWork,
                                                    ITransmissionTypeSpecification specification,
                                                    IQueryFilterParser queryFilterParser,
                                                    IMapper mapper)
  : UpdateEntityCommandHandler<TransmissionType, UpdateTransmissionTypeDTO, UpdateTransmissionTypeCommand>(specification,
                                                                                                           queryFilterParser,
                                                                                                           mapper)
{
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

  protected override void UpdateEntity(TransmissionType entity)
  {
    transmissionTypeUnitOfWork.TransmissionTypies.ReplaceOne(entity);
    transmissionTypeUnitOfWork.Complete();
  }
}
