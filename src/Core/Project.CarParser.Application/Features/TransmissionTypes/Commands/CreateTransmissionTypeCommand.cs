namespace Project.CarParser.Application.Features.TransmissionTypes.Commands;

public record CreateTransmissionTypeCommand(CreateTransmissionTypeDTO TransmissionTypeDTO)
  : CreateEntityCommand<CreateTransmissionTypeDTO>(TransmissionTypeDTO);

internal class CreateTransmissionTypeCommandHandler(ITransmissionTypeUnitOfWork transmissionTypeUnitOfWork,
                                                    ITransmissionTypeSpecification specification,
                                                    IQueryFilterParser queryFilterParser,
                                                    IMapper mapper)
  : CreateEntityCommandHandler<TransmissionType, CreateTransmissionTypeDTO, CreateTransmissionTypeCommand>(specification,
                                                                                                           mapper)
{
  protected override Expression<Func<TransmissionType, bool>>? BuildDuplicateCheckFilter(CreateTransmissionTypeDTO createDto)
    => queryFilterParser.ParseFilters<TransmissionType>(new RequestParameters
    {
      Filters =
        [
          new()
          {
            PropertyPath = nameof(TransmissionType.Name),
            Operator = FilterOperator.Equals,
            Value = createDto.Name
          }
        ]
    }.Filters);

  protected override void PersistNewEntity(TransmissionType entity)
  {
    transmissionTypeUnitOfWork.StartTransaction();
    transmissionTypeUnitOfWork.TransmissionTypies.InsertOne(entity);
    transmissionTypeUnitOfWork.Complete();
  }

  protected override async Task ValidateEntityDoesNotExistAsync(ISpecification<TransmissionType> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await transmissionTypeUnitOfWork.TransmissionTypies.AnyByQueryAsync(specification,
                                                                                      cancellationToken);

    if (exists is true)
      throw new EntityAlreadyExists(typeof(TransmissionType), specification.ToString() ?? string.Empty);
  }
}
