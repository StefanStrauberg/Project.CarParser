namespace Project.CarParser.Application.DTOs.BodyTypes;

public class UpdateBodyTypeDTO : BaseBodyTypeDTO, IMapWith<BodyType>
{
  public Guid Id { get; set; }

  void IMapWith<BodyType>.Mapping(Profile profile)
  {
    profile.CreateMap<UpdateBodyTypeDTO, BodyType>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}