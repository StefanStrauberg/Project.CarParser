namespace Project.CarParser.Application.DTOs.PlaceCities;

public class ShortPlaceCityDTO : BasePlaceCityDTO, IMapWith<PlaceCity>
{
  public Guid Id { get; set; }

  void IMapWith<PlaceCity>.Mapping(Profile profile)
  {
    profile.CreateMap<PlaceCity, ShortPlaceCityDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id));
  }
}
