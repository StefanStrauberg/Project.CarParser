namespace Project.CarParser.Application.DTOs.TransmissionTypes;

public class BaseTransmissionTypeDTO : IMapWith<TransmissionType>
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }

  void IMapWith<TransmissionType>.Mapping(Profile profile)
  {
    profile.CreateMap<TransmissionType, BaseTransmissionTypeDTO>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                    opt => opt.MapFrom(src => src.Number));
  }
}
