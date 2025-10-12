namespace Project.CarParser.Application.DTOs.PlaceCities;

public class UpdatePlaceCityDTO : BasePlaceCityDTO, IMapWith<PlaceCity>
{
  public Guid Id { get; set; }

  void IMapWith<PlaceCity>.Mapping(Profile profile)
  {
    profile.CreateMap<UpdatePlaceCityDTO, PlaceCity>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
