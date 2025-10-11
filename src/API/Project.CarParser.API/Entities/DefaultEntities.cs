namespace Project.CarParser.API.Entities;

public static class DefaultEntities
{
  /// <summary>
  /// The default CORS policy name used for cross-origin configuration.
  /// </summary>
  public static string CorsPolicyName { get; } = "CorsPolicy";

  /// <summary>
  /// The name of the response header that exposes pagination metadata.
  /// </summary>
  public static string ExposedHeaders { get; } = "X-Pagination";
}
