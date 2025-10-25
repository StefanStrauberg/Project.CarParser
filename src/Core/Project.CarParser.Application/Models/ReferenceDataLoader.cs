namespace Project.CarParser.Application.Models;

public class ReferenceDataLoader(ITransmissionTypeUnitOfWork transmission,
                                 IEngineTypeUnitOfWork engine,
                                 IBodyTypeUnitOfWork body,
                                 IPlaceCityUnitOfWork city,
                                 IPlaceRegionUnitOfWork region)
{
  public async Task<ReferenceMaps> LoadAsync(CancellationToken ct)
  {
    var transmissionMap = await LoadDictionaryAsync(transmission.TransmissionTypies, ct);
    var engineMap = await LoadDictionaryAsync(engine.EngineTypes, ct);
    var bodyMap = await LoadDictionaryAsync(body.BodyTypes, ct);
    var cityMap = await LoadDictionaryAsync(city.PlaceCities, ct);
    var regionMap = await LoadDictionaryAsync(region.PlaceRegions, ct);

    return new ReferenceMaps(transmissionMap, engineMap, bodyMap, cityMap, regionMap);
  }

  static async Task<Dictionary<string, Guid>> LoadDictionaryAsync<T>(IRepository<T> repository,
                                                                     CancellationToken cancellationToken) where T : BaseEntity
  {
    var all = await repository.GetManyShortAsync(null!, cancellationToken);
    return all.Where(x => x is INameEntity)
              .Cast<INameEntity>()
              .ToDictionary(x => x.Name.ToLowerInvariant().Trim(),
                            x => x.Id);
  }
}
