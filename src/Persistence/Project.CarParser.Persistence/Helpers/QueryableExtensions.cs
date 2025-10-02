namespace Project.CarParser.Persistence.Helpers;

internal static class QueryableExtensions
{
  /// <summary>
  /// Applies a <c>Take</c> clause to the query if the value is greater than zero.
  /// </summary>
  /// <typeparam name="T">The entity type.</typeparam>
  /// <param name="query">The base query.</param>
  /// <param name="take">The number of items to take.</param>
  /// <returns>The modified query with the <c>Take</c> applied.</returns>
  public static IQueryable<T> ApplyTake<T>(this IQueryable<T> query, int take)
    => take > 0 ? query.Take(take) : query;

  /// <summary>
  /// Applies a <c>Skip</c> clause to the query if the value is greater than zero.
  /// </summary>
  /// <typeparam name="T">The entity type.</typeparam>
  /// <param name="query">The base query.</param>
  /// <param name="skip">The number of items to skip.</param>
  /// <returns>The modified query with the <c>Skip</c> applied.</returns>
  public static IQueryable<T> ApplySkip<T>(this IQueryable<T> query, int skip)
    => skip > 0 ? query.Skip(skip) : query;

  /// <summary>
  /// Applies a filtering expression to the query.
  /// </summary>
  /// <typeparam name="T">The entity type.</typeparam>
  /// <param name="query">The base query.</param>
  /// <param name="criterias">The filtering expression.</param>
  /// <returns>The modified query with the filter applied, or the original if null.</returns>
  public static IQueryable<T> ApplyWhere<T>(this IQueryable<T> query, Expression<Func<T, bool>>? criterias)
  {
    if (criterias is null)
      return query;

    var visitor = new ILikeExpressionVisitor();
    var modifiedBody = visitor.Visit(criterias.Body);
    var modifiedLambda = Expression.Lambda<Func<T, bool>>(modifiedBody!, criterias.Parameters);

    return query.Where(modifiedLambda);
  }

  /// <summary>
  /// Applies sorting to the query based on the provided key selector.
  /// </summary>
  /// <typeparam name="T">The entity type.</typeparam>
  /// <typeparam name="TKey">The type of the sorting key.</typeparam>
  /// <param name="query">The base query.</param>
  /// <param name="keySelector">The expression specifying the sort key.</param>
  /// <param name="descending">Whether to sort in descending order.</param>
  /// <returns>The modified query with sorting applied, or the original if selector is null.</returns>
  public static IQueryable<T> ApplyOrderBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>>? keySelector, bool descending = false)
  {
    if (keySelector is null)
      return query;

    return descending ? query.OrderByDescending(keySelector) : query.OrderBy(keySelector);
  }
}