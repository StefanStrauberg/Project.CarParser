namespace Project.CarParser.CarListingScraper;

/// <summary>
/// Provides extension methods for registering query filter parser services used in specification construction.
/// </summary>
public static class CarListingScraperServicesRegistration
{
  /// <summary>
  /// Registers the <see cref="IQueryFilterParser"/> implementation for parsing structured filter definitions.
  /// </summary>
  /// <param name="services">The service collection to which the parser service is added.</param>
  /// <returns>The updated <see cref="IServiceCollection"/> for fluent chaining.</returns>
  public static IServiceCollection AddQueryFilterParserServices(this IServiceCollection services)
  {

    return services;
  }
}
