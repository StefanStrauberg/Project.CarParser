namespace Project.CarParser.Application.DTOs.EngineTypes;

public class UpdateEngineTypeDTO : BaseEngineTypeDTO, IMapWith<EngineType>
{
  public Guid Id { get; set; }

  void IMapWith<EngineType>.Mapping(Profile profile)
  {
    profile.CreateMap<UpdateEngineTypeDTO, EngineType>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
