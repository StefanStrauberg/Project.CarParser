namespace Project.CarParser.Application.DTOs.BodyTypes;

public class BaseBodyTypeDTO : IMapWith<BodyType>
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }

  void IMapWith<BodyType>.Mapping(Profile profile)
  {
    profile.CreateMap<BodyType, BaseBodyTypeDTO>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                    opt => opt.MapFrom(src => src.Number));
  }
}
