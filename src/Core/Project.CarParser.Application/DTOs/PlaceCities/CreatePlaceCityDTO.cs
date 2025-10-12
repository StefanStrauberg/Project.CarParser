namespace Project.CarParser.Application.DTOs.PlaceCities;

public class CreatePlaceCityDTO : BasePlaceCityDTO, IMapWith<PlaceCity>
{
  void IMapWith<PlaceCity>.Mapping(Profile profile)
  {
    profile.CreateMap<CreatePlaceCityDTO, PlaceCity>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
