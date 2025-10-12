namespace Project.CarParser.Application.DTOs.TransmissionTypes;

public class CreateTransmissionTypeDTO : BaseTransmissionTypeDTO, IMapWith<TransmissionType>
{
  void IMapWith<TransmissionType>.Mapping(Profile profile)
  {
    profile.CreateMap<CreateTransmissionTypeDTO, TransmissionType>()
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
