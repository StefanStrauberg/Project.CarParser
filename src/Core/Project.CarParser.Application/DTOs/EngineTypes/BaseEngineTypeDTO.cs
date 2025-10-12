namespace Project.CarParser.Application.DTOs.EngineTypes;

public class BaseEngineTypeDTO : IMapWith<EngineType>
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }

  void IMapWith<EngineType>.Mapping(Profile profile)
  {
    profile.CreateMap<EngineType, BaseEngineTypeDTO>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                    opt => opt.MapFrom(src => src.Number));
  }
}
