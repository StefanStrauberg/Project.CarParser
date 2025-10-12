namespace Project.CarParser.Application.Features.EngineTypes.Commands;

public record UpdateEngineTypeCommand(UpdateEngineTypeDTO UpdateEngineTypeDTO)
  : UpdateEntityCommand<EngineType, UpdateEngineTypeDTO>(UpdateEngineTypeDTO.Id, UpdateEngineTypeDTO);

internal class UpdateEngineTypeCommandHandler(IEngineTypeUnitOfWork EngineTypeUnitOfWork,
                                              IEngineTypeSpecification specification,
                                              IQueryFilterParser queryFilterParser,
                                              IMapper mapper)
  : UpdateEntityCommandHandler<EngineType, UpdateEngineTypeDTO, UpdateEngineTypeCommand>(specification,
                                                                                         queryFilterParser,
                                                                                         mapper)
{
  protected override async Task EnsureEntityExistAsync(ISpecification<EngineType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await EngineTypeUnitOfWork.EngineTypes.AnyByQueryAsync(specification,
                                                                          cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(EngineType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<EngineType> FetchEntityAsync(ISpecification<EngineType> specification,
                                                             CancellationToken cancellationToken)
    => await EngineTypeUnitOfWork.EngineTypes.GetOneShortAsync(specification, cancellationToken);

  protected override void UpdateEntity(EngineType entity)
  {
    EngineTypeUnitOfWork.EngineTypes.ReplaceOne(entity);
    EngineTypeUnitOfWork.Complete();
  }
}
