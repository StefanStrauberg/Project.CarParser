namespace Project.CarParser.Application.DTOs.PlaceCities;

public class DetailPlaceCityDTO : BasePlaceCityDTO, IMapWith<PlaceCity>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  void IMapWith<PlaceCity>.Mapping(Profile profile)
  {
    profile.CreateMap<PlaceCity, DetailPlaceCityDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.CreatedAt,
                      opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.UpdatedAt,
                      opt => opt.MapFrom(src => src.UpdatedAt));
  }
}
