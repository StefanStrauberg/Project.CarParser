namespace Project.CarParser.Application.DTOs.TransmissionTypes;

public class DetailTransmissionTypeDTO : BaseTransmissionTypeDTO, IMapWith<TransmissionType>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  void IMapWith<TransmissionType>.Mapping(Profile profile)
  {
    profile.CreateMap<TransmissionType, DetailTransmissionTypeDTO>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.CreatedAt,
                      opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.UpdatedAt,
                      opt => opt.MapFrom(src => src.UpdatedAt));
  }
}
