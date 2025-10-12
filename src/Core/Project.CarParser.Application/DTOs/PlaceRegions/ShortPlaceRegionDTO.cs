namespace Project.CarParser.Application.DTOs.PlaceRegions;

public class ShortPlaceRegionDTO : BasePlaceRegionDTO, IMapWith<PlaceRegion>
{
  public Guid Id { get; set; }

  void IMapWith<PlaceRegion>.Mapping(Profile profile)
  {
    profile.CreateMap<PlaceRegion, ShortPlaceRegionDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id));
  }
}
