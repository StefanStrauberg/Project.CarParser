namespace Project.CarParser.Application.DTOs.CarListings;

public class ShortCarListingDTO : BaseCarListingDTO, IMapWith<CarListing>
{
  public Guid Id { get; set; }
  public string? PlaceRegion { get; set; }
  public string PlaceCity { get; set; } = string.Empty;
  public string TransmissionType { get; set; } = string.Empty;
  public string EngineType { get; set; } = string.Empty;
  public string BodyType { get; set; } = string.Empty;

  void IMapWith<CarListing>.Mapping(Profile profile)
  {
    profile.CreateMap<CarListing, ShortCarListingDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.PlaceRegion,
                      opt => opt.MapFrom(src => src.PlaceRegion != null ? src.PlaceRegion.Name : null))
           .ForMember(dest => dest.PlaceCity,
                      opt => opt.MapFrom(src => src.PlaceCity.Name))
           .ForMember(dest => dest.TransmissionType,
                      opt => opt.MapFrom(src => src.TransmissionType.Name))
           .ForMember(dest => dest.EngineType,
                      opt => opt.MapFrom(src => src.EngineType.Name))
           .ForMember(dest => dest.BodyType,
                      opt => opt.MapFrom(src => src.BodyType.Name));
  }
}
