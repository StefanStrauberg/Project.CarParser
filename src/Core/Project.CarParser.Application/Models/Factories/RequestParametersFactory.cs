namespace Project.CarParser.Application.Models.Factories;

/// <summary>
/// Provides factory methods for creating <see cref="RequestParameters"/> with predefined filters.
/// </summary>
internal static class RequestParametersFactory
{
  /// <summary>
  /// Creates request parameters for filtering entities by their unique identifier.
  /// </summary>
  /// <param name="id">The GUID identifier to filter by.</param>
  /// <returns>
  /// A <see cref="RequestParameters"/> instance with a filter targeting the <c>Id</c> property.
  /// </returns>
  /// <remarks>
  /// Commonly used for entity retrieval by primary key.
  /// </remarks>
  public static RequestParameters ForId(Guid id) => new()
  {
    Filters = [new FilterDescriptor
    {
      PropertyPath = "Id",
      Operator = FilterOperator.Equals,
      Value = id.ToString()
    }]
  };

  public static RequestParameters Empty() => new()
  { };
}
