namespace Project.CarParser.Domain;

public class CarListing : BaseEntity
{
  // Main information
  public string Title { get; set; } = string.Empty; // Citroen C5 I
  public string Url { get; set; } = string.Empty; // citroen/c5/116079518
  public string FullUrl => $"https://cars.av.by{Url}";  // /citroen/c5/116079518

  // Prices
  public int PricePrimary { get; set; } // 9 546 р.
  public int PriceSecondary { get; set; } // 3 200 $

  // Car properties
  public int Year { get; set; } // 2001
  public Guid TransmissionTypeId { get; set; }
  public TransmissionType TransmissionType { get; set; } = null!; // automatic
  public double EngineVolume { get; set; }  // 2,0 л
  public Guid EngineTypeId { get; set; }
  public EngineType EngineType { get; set; } = null!; // diesel
  public int Mileage { get; set; }
  public Guid BodyTypeId { get; set; }
  public BodyType BodyType { get; set; } = null!; // лифтбек

  // Additional information
  public Guid? PlaceRegionId { get; set; }
  public PlaceRegion? PlaceRegion { get; set; } // -
  public Guid PlaceCityId { get; set; }
  public PlaceCity PlaceCity { get; set; } = null!; // Minsk
  public DateTime PublishDate { get; set; } // from now - (30 minutes)

  // Badges and statuses
  public bool HasVin { get; set; } // true

  // Images
  public string? FirstImageUrl { get; set; } // https://avcdn.av.by/advertpreview/0005/5138/3575.jpg
}