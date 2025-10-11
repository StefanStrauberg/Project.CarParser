namespace Project.CarParser.Application.DTOs.BodyTypes;

public class UpdateBodyTypeDTO : BaseBodyTypeDTO, IMapWith<BodyType>
{
  public Guid Id { get; set; }

  void IMapWith<BodyType>.Mapping(Profile profile)
  {
    profile.CreateMap<BodyType, ShortBodyTypeDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id));
  }
}