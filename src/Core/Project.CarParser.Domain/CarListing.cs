namespace Project.CarParser.Domain;

public class CarListing : BaseEntity
{
  public string? Title { get; set; }
  public int Price { get; set; }
  public PlaceRegion PlaceRegion { get; set; }
  public PlaceCity PlaceCity { get; set; }
  public string? Description { get; set; }
  public string? Url { get; set; }
  public int ManufactureYear { get; set; }
  public decimal EngineDisplacement { get; set; }
  public TransmissionType TransmissionType { get; set; }
  public EngineType EngineType { get; set; }
  public BodyType BodyType { get; set; }
  public DateTime PublishDate { get; set; }
}
