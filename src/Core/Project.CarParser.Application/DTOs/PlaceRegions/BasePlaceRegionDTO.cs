namespace Project.CarParser.Application.DTOs.PlaceRegions;

public class BasePlaceRegionDTO : IMapWith<PlaceRegion>
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }

  void IMapWith<PlaceRegion>.Mapping(Profile profile)
  {
    profile.CreateMap<PlaceRegion, BasePlaceRegionDTO>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                    opt => opt.MapFrom(src => src.Number));
  }
}
