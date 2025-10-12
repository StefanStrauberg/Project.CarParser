namespace Project.CarParser.Application.DTOs.PlaceRegions;

public class UpdatePlaceRegionDTO : BasePlaceRegionDTO, IMapWith<PlaceRegion>
{
  public Guid Id { get; set; }

  void IMapWith<PlaceRegion>.Mapping(Profile profile)
  {
    profile.CreateMap<UpdatePlaceRegionDTO, PlaceRegion>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
