namespace Project.CarParser.Specification;

internal class IncludeChain<TBase> : IIncludeChain<TBase> where TBase : BaseEntity
{
  readonly List<IncludeChainItem> _includes = [];

  public IReadOnlyList<(Type EntityType, Type PropertyType, LambdaExpression Expression)> Includes
    => [.. _includes.Select(x => (x.EntityType, x.PropertyType, x.Expression))];

  public IIncludeChain<TBase> AddInclude<TProperty>(Expression<Func<TBase, TProperty>> include)
  {
    _includes.Add(new IncludeChainItem(typeof(TBase), typeof(TProperty), include));
    return this;
  }

  public void AddTypedInclude<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> include)
    => _includes.Add(new IncludeChainItem(typeof(TEntity), typeof(TProperty), include));

  record IncludeChainItem(Type EntityType, Type PropertyType, LambdaExpression Expression);
}
