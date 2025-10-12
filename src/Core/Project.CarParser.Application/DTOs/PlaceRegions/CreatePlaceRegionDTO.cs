namespace Project.CarParser.Application.DTOs.PlaceRegions;

public class CreatePlaceRegionDTO : BasePlaceRegionDTO, IMapWith<PlaceRegion>
{
  void IMapWith<PlaceRegion>.Mapping(Profile profile)
  {
    profile.CreateMap<CreatePlaceRegionDTO, PlaceRegion>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
