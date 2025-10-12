namespace Project.CarParser.Application.DTOs.BodyTypes;

public class CreateBodyTypeDTO : BaseBodyTypeDTO, IMapWith<BodyType>
{
  void IMapWith<BodyType>.Mapping(Profile profile)
  {
    profile.CreateMap<CreateBodyTypeDTO, BodyType>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
