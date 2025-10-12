namespace Project.CarParser.Application.Contracts.Specification;

public interface IIncludeChain<TBase> where TBase : BaseEntity
{
  /// <summary>
  /// Gets the ordered collection of include expressions, 
  /// each representing a navigation path to be applied during query execution.
  /// </summary>
  IReadOnlyList<(Type EntityType, Type PropertyType, LambdaExpression Expression)> Includes { get; }

  /// <summary>
  /// Adds a direct navigation property to the include chain.
  /// </summary>
  /// <typeparam name="TProperty">The type of the property to include.</typeparam>
  /// <param name="include">A lambda expression identifying the navigation property from <typeparamref name="TBase"/>.</param>
  /// <returns>The updated <see cref="IIncludeChain{TBase}"/> for chaining.</returns>
  IIncludeChain<TBase> AddInclude<TProperty>(Expression<Func<TBase, TProperty>> include);
}
