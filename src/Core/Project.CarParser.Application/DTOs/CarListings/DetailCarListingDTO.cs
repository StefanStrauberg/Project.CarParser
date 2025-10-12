namespace Project.CarParser.Application.DTOs.CarListings;

public class DetailCarListingDTO : BaseCarListingDTO, IMapWith<CarListing>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public ShortPlaceRegionDTO PlaceRegion { get; set; } = null!;
  public ShortPlaceCityDTO PlaceCity { get; set; } = null!;
  public ShortTransmissionTypeDTO TransmissionType { get; set; } = null!;
  public ShortEngineTypeDTO EngineType { get; set; } = null!;
  public ShortBodyTypeDTO BodyType { get; set; } = null!;

  void IMapWith<CarListing>.Mapping(Profile profile)
  {
    profile.CreateMap<CarListing, DetailCarListingDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.CreatedAt,
                      opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.UpdatedAt,
                      opt => opt.MapFrom(src => src.UpdatedAt))
           .ForMember(dest => dest.PlaceRegion,
                      opt => opt.MapFrom(src => src.PlaceRegion))
           .ForMember(dest => dest.PlaceCity,
                      opt => opt.MapFrom(src => src.PlaceCity))
           .ForMember(dest => dest.TransmissionType,
                      opt => opt.MapFrom(src => src.TransmissionType))
           .ForMember(dest => dest.EngineType,
                      opt => opt.MapFrom(src => src.EngineType))
           .ForMember(dest => dest.BodyType,
                      opt => opt.MapFrom(src => src.BodyType));
  }
}
