namespace Project.CarParser.Application.Models;

public class RawCarListingMapper
{
  public static IEnumerable<CreateCarListingDTO> Map(IEnumerable<RawCarListing> raw,
                                                     ReferenceMaps map)
  {
    return raw.Select(r => new CreateCarListingDTO
    {
      Title = r.Title?.Trim() ?? string.Empty,
      Url = r.Url?.Trim() ?? string.Empty,
      PricePrimary = ParseInt(r.PricePrimary),
      PriceSecondary = ParseInt(r.PriceSecondary),
      Year = ParseInt(r.Year),
      TransmissionTypeId = MapGuid(r.Transmission, map.Transmission),
      EngineTypeId = MapGuid(r.FuelType, map.Engine),
      EngineVolume = ParseDouble(r.EngineVolume),
      Mileage = ParseInt(r.Mileage),
      BodyTypeId = MapGuid(r.BodyType, map.Body),
      PlaceCityId = MapGuid(r.Location, map.City),
      PlaceRegionId = MapGuid(r.Location, map.Region),
      PublishDate = ParseDate(r.Date),
      HasVin = r.HasVin,
      FirstImageUrl = r.FirstImageUrl?.Trim()
    });
  }

  static int ParseInt(string? value)
    => int.TryParse(value?.Replace(" ", "").Replace("км", "").Replace(" ", ""), out var r) ? r : 0;

  static double ParseDouble(string? value)
    => double.TryParse(value?.Replace("л", "").Replace(",", ".").Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var r) ? r : 0;

  static DateTime ParseDate(string? value)
    => DateTime.TryParse(value, out var r) ? r : DateTime.UtcNow;

  static Guid MapGuid(string? key, IReadOnlyDictionary<string, Guid> map)
    => key is not null && map.TryGetValue(key.ToLowerInvariant().Trim(), out var id) ? id : Guid.Empty;
}
