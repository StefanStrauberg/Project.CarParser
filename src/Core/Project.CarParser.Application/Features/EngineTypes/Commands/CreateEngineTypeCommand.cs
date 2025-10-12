namespace Project.CarParser.Application.Features.EngineTypes.Commands;

public record CreateEngineTypeCommand(CreateEngineTypeDTO EngineTypeDTO)
  : CreateEntityCommand<CreateEngineTypeDTO>(EngineTypeDTO);

internal class CreateEngineTypeCommandHandler(IEngineTypeUnitOfWork EngineTypeUnitOfWork,
                                              IEngineTypeSpecification specification,
                                              IQueryFilterParser queryFilterParser,
                                              IMapper mapper)
  : CreateEntityCommandHandler<EngineType, CreateEngineTypeDTO, CreateEngineTypeCommand>(specification,
                                                                                   mapper)
{
  protected override Expression<Func<EngineType, bool>>? BuildDuplicateCheckFilter(CreateEngineTypeDTO createDto)
    => queryFilterParser.ParseFilters<EngineType>(new RequestParameters
    {
      Filters =
        [
          new()
          {
            PropertyPath = nameof(EngineType.Name),
            Operator = FilterOperator.Equals,
            Value = createDto.Name
          }
        ]
    }.Filters);

  protected override void PersistNewEntity(EngineType entity)
  {
    EngineTypeUnitOfWork.StartTransaction();
    EngineTypeUnitOfWork.EngineTypes.InsertOne(entity);
    EngineTypeUnitOfWork.Complete();
  }

  protected override async Task ValidateEntityDoesNotExistAsync(ISpecification<EngineType> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await EngineTypeUnitOfWork.EngineTypes.AnyByQueryAsync(specification,
                                                                          cancellationToken);

    if (exists is true)
      throw new EntityAlreadyExists(typeof(EngineType), specification.ToString() ?? string.Empty);
  }
}
