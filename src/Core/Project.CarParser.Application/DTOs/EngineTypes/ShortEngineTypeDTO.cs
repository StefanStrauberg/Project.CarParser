namespace Project.CarParser.Application.DTOs.EngineTypes;

public class ShortEngineTypeDTO : BaseEngineTypeDTO, IMapWith<EngineType>
{
  public Guid Id { get; set; }

  void IMapWith<EngineType>.Mapping(Profile profile)
  {
    profile.CreateMap<EngineType, ShortEngineTypeDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id));
  }
}
