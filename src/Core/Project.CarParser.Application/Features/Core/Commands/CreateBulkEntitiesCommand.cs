namespace Project.CarParser.Application.Features.Core.Commands;

public abstract record CreateBulkEntitiesCommand<TCreateDto>(IEnumerable<TCreateDto> CreateDtos)
  : ICommand<Unit>;

internal abstract class CreateBulkEntitiesCommandHandler<TEntity, TDto, TCommand>(ISpecification<TEntity> specification,
                                                                                  IMapper mapper)
  : ICommandHandler<TCommand, Unit>
  where TEntity : BaseEntity
  where TDto : class
  where TCommand : CreateBulkEntitiesCommand<TDto>
{
  public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
  {
    var filter = BuildDuplicateCheckFilter(request.CreateDtos);
    var specification = BuildSpecification(filter);

    await ValidateEntitiesDoNotExistAsync(specification, cancellationToken);

    var newEntities = MapToEntities(request.CreateDtos);
    PersistNewEntities(newEntities);

    return Unit.Value;
  }

  protected abstract Expression<Func<TEntity, bool>>? BuildDuplicateCheckFilter(IEnumerable<TDto> dtos);

  protected virtual ISpecification<TEntity> BuildSpecification(Expression<Func<TEntity, bool>>? filterExpr)
  {
    var spec = specification.Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected abstract Task ValidateEntitiesDoNotExistAsync(ISpecification<TEntity> specification,
                                                          CancellationToken cancellationToken);

  protected IEnumerable<TEntity> MapToEntities(IEnumerable<TDto> dtos)
    => mapper.Map<IEnumerable<TEntity>>(dtos);

  protected abstract void PersistNewEntities(IEnumerable<TEntity> entities);
}