namespace Project.CarParser.Persistence.Helpers;

public class ILikeExpressionVisitor : ExpressionVisitor
{
  static readonly MethodInfo ILikeMethod = typeof(NpgsqlDbFunctionsExtensions).GetMethod(nameof(NpgsqlDbFunctionsExtensions.ILike),
                                                                                         [typeof(DbFunctions),
                                                                                         typeof(string),
                                                                                         typeof(string)])!;

  static readonly MethodInfo ConcatMethod = typeof(string).GetMethod(nameof(string.Concat),
                                                                     [typeof(string), typeof(string), typeof(string)])!;

  protected override Expression VisitMethodCall(MethodCallExpression node)
  {
    if (node.Method.Name == nameof(string.Contains) &&
        node.Object?.Type == typeof(string) &&
        node.Arguments.Count == 1 &&
        node.Arguments[0].Type == typeof(string))
    {
      var instance = node.Object;
      var argument = node.Arguments[0];

      var patternExpression = Expression.Call(ConcatMethod, Expression.Constant("%"), argument, Expression.Constant("%"));

      return Expression.Call(ILikeMethod,
                             Expression.Constant(EF.Functions),
                             instance!,
                             patternExpression);
    }

    return base.VisitMethodCall(node);
  }
}
