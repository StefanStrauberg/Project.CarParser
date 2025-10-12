namespace Project.CarParser.Application.DTOs.TransmissionTypes;

public class UpdateTransmissionTypeDTO : BaseTransmissionTypeDTO, IMapWith<TransmissionType>
{
  public Guid Id { get; set; }

  void IMapWith<TransmissionType>.Mapping(Profile profile)
  {
    profile.CreateMap<UpdateTransmissionTypeDTO, TransmissionType>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Number,
                      opt => opt.MapFrom(src => src.Number));
  }
}
