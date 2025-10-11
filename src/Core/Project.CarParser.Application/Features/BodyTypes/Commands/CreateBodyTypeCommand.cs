namespace Project.CarParser.Application.Features.BodyTypes.Commands;

public record CreateBodyTypeCommand(CreateBodyTypeDTO BodyTypeDTO)
  : CreateEntityCommand<CreateBodyTypeDTO>(BodyTypeDTO);

internal class CreateBodyTypeCommandHandler(IBodyTypeUnitOfWork bodyTypeUnitOfWork,
                                            IBodyTypeSpecification specification,
                                            IQueryFilterParser queryFilterParser,
                                            IMapper mapper)
  : CreateEntityCommandHandler<BodyType, CreateBodyTypeDTO, CreateBodyTypeCommand>(specification,
                                                                                   mapper)
{
  protected override Expression<Func<BodyType, bool>>? BuildDuplicateCheckFilter(CreateBodyTypeDTO createDto)
    => queryFilterParser.ParseFilters<BodyType>(new RequestParameters
    {
      Filters =
        [
          new()
          {
            PropertyPath = nameof(BodyType.Name),
            Operator = FilterOperator.Equals,
            Value = createDto.Name
          }
        ]
    }.Filters);

  protected override void PersistNewEntity(BodyType entity)
  {
    bodyTypeUnitOfWork.StartTransaction();
    bodyTypeUnitOfWork.BodyTypies.InsertOne(entity);
    bodyTypeUnitOfWork.Complete();
  }

  protected override async Task ValidateEntityDoesNotExistAsync(ISpecification<BodyType> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await bodyTypeUnitOfWork.BodyTypies.AnyByQueryAsync(specification,
                                                                      cancellationToken);

    if (exists is true)
      throw new EntityAlreadyExists(typeof(BodyType), specification.ToString() ?? string.Empty);
  }
}
