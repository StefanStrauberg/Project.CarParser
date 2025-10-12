namespace Project.CarParser.Application.Features.BodyTypes.Commands;

public record UpdateBodyTypeCommand(UpdateBodyTypeDTO UpdateBodyTypeDTO)
  : UpdateEntityCommand<BodyType, UpdateBodyTypeDTO>(UpdateBodyTypeDTO.Id, UpdateBodyTypeDTO);

internal class UpdateBodyTypeCommandHandler(IBodyTypeUnitOfWork bodyTypeUnitOfWork,
                                            IBodyTypeSpecification specification,
                                            IQueryFilterParser queryFilterParser,
                                            IMapper mapper)
  : UpdateEntityCommandHandler<BodyType, UpdateBodyTypeDTO, UpdateBodyTypeCommand>(specification,
                                                                                   queryFilterParser,
                                                                                   mapper)
{
  protected override async Task EnsureEntityExistAsync(ISpecification<BodyType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await bodyTypeUnitOfWork.BodyTypes.AnyByQueryAsync(specification,
                                                                      cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(BodyType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<BodyType> FetchEntityAsync(ISpecification<BodyType> specification,
                                                           CancellationToken cancellationToken)
    => await bodyTypeUnitOfWork.BodyTypes.GetOneShortAsync(specification, cancellationToken);

  protected override void UpdateEntity(BodyType entity)
  {
    bodyTypeUnitOfWork.BodyTypes.ReplaceOne(entity);
    bodyTypeUnitOfWork.Complete();
  }
}
