namespace Project.CarParser.Application.DTOs.PlaceCities;

public class BasePlaceCityDTO : IMapWith<PlaceCity>
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }

  void IMapWith<PlaceCity>.Mapping(Profile profile)
  {
    profile.CreateMap<PlaceCity, BasePlaceCityDTO>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                    opt => opt.MapFrom(src => src.Number));
  }
}
