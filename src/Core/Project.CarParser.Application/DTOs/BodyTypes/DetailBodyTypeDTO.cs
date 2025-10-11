namespace Project.CarParser.Application.DTOs.BodyTypes;

public class DetailBodyTypeDTO : BaseBodyTypeDTO, IMapWith<BodyType>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  void IMapWith<BodyType>.Mapping(Profile profile)
  {
    profile.CreateMap<BodyType, DetailBodyTypeDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.CreatedAt,
                      opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.UpdatedAt,
                      opt => opt.MapFrom(src => src.UpdatedAt));
  }
}
