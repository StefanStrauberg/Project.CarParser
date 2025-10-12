namespace Project.CarParser.Application.DTOs.EngineTypes;

public class DetailEngineTypeDTO : BaseEngineTypeDTO, IMapWith<EngineType>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  void IMapWith<EngineType>.Mapping(Profile profile)
  {
    profile.CreateMap<EngineType, DetailEngineTypeDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.CreatedAt,
                      opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.UpdatedAt,
                      opt => opt.MapFrom(src => src.UpdatedAt));
  }
}
