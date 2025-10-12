namespace Project.CarParser.Application.DTOs.PlaceRegions;

public class DetailPlaceRegionDTO : BasePlaceRegionDTO, IMapWith<PlaceRegion>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  void IMapWith<PlaceRegion>.Mapping(Profile profile)
  {
    profile.CreateMap<PlaceRegion, DetailPlaceRegionDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.CreatedAt,
                      opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.UpdatedAt,
                      opt => opt.MapFrom(src => src.UpdatedAt));
  }
}
