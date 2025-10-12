namespace Project.CarParser.Application.DTOs.CarListings;

public class CreateCarListingDTO : BaseCarListingDTO, IMapWith<CarListing>
{
  public Guid PlaceRegionId { get; set; }
  public Guid PlaceCityId { get; set; }
  public Guid TransmissionTypeId { get; set; }
  public Guid EngineTypeId { get; set; }
  public Guid BodyTypeId { get; set; }

  void IMapWith<CarListing>.Mapping(Profile profile)
  {
    profile.CreateMap<CreateCarListingDTO, CarListing>()
           .ForMember(dest => dest.Title,
                      opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price))
           .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.Url,
                    opt => opt.MapFrom(src => src.Url))
           .ForMember(dest => dest.ManufactureYear,
                    opt => opt.MapFrom(src => src.ManufactureYear))
           .ForMember(dest => dest.EngineDisplacement,
                    opt => opt.MapFrom(src => src.EngineDisplacement))
           .ForMember(dest => dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate));
  }
}
