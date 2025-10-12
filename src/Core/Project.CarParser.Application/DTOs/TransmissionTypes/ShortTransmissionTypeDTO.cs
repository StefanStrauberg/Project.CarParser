namespace Project.CarParser.Application.DTOs.TransmissionTypes;

public class ShortTransmissionTypeDTO : BaseTransmissionTypeDTO, IMapWith<TransmissionType>
{
  public Guid Id { get; set; }

  void IMapWith<TransmissionType>.Mapping(Profile profile)
  {
    profile.CreateMap<TransmissionType, ShortTransmissionTypeDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id));
  }
}
