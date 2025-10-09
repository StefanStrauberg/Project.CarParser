namespace Project.CarParser.Domain;

public class CarListing : BaseEntity
{
  public string Title { get; set; } = string.Empty;
  public int Price { get; set; }
  public string? Description { get; set; }
  public string Url { get; set; } = string.Empty;
  public int ManufactureYear { get; set; }
  public decimal EngineDisplacement { get; set; }
  public DateTime PublishDate { get; set; }
  public Guid PlaceRegionId { get; set; }
  public PlaceRegion PlaceRegion { get; set; } = null!;
  public Guid PlaceCityId { get; set; }
  public PlaceCity PlaceCity { get; set; } = null!;
  public Guid TransmissionTypeId { get; set; }
  public TransmissionType TransmissionType { get; set; } = null!;
  public Guid EngineTypeId { get; set; }
  public EngineType EngineType { get; set; } = null!;
  public Guid BodyTypeId { get; set; }
  public BodyType BodyType { get; set; } = null!;
}