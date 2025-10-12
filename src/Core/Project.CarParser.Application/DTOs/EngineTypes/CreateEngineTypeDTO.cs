namespace Project.CarParser.Application.DTOs.EngineTypes;

public class CreateEngineTypeDTO : BaseEngineTypeDTO, IMapWith<EngineType>
{
  void IMapWith<EngineType>.Mapping(Profile profile)
  {
    profile.CreateMap<CreateEngineTypeDTO, EngineType>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
