namespace Project.CarParser.Application.DTOs.CarListings;

public class UpdateCarListingDTO : BaseCarListingDTO, IMapWith<CarListing>
{
  public Guid Id { get; set; }
  public Guid PlaceRegionId { get; set; }
  public Guid PlaceCityId { get; set; }
  public Guid TransmissionTypeId { get; set; }
  public Guid EngineTypeId { get; set; }
  public Guid BodyTypeId { get; set; }
  void IMapWith<CarListing>.Mapping(Profile profile)
  {
    profile.CreateMap<UpdateCarListingDTO, CarListing>()
           .ForMember(dest => dest.Id,
                      opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Title,
                      opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Url,
                    opt => opt.MapFrom(src => src.Url))
           .ForMember(dest => dest.FullUrl,
                    opt => opt.MapFrom(src => src.FullUrl))
           .ForMember(dest => dest.PricePrimary,
                    opt => opt.MapFrom(src => src.PricePrimary))
           .ForMember(dest => dest.PriceSecondary,
                    opt => opt.MapFrom(src => src.PriceSecondary))
           .ForMember(dest => dest.Year,
                    opt => opt.MapFrom(src => src.Year))
           .ForMember(dest => dest.EngineVolume,
                    opt => opt.MapFrom(src => src.EngineVolume))
           .ForMember(dest => dest.Mileage,
                    opt => opt.MapFrom(src => src.Mileage))
           .ForMember(dest => dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate))
           .ForMember(dest => dest.HasVin,
                    opt => opt.MapFrom(src => src.HasVin))
           .ForMember(dest => dest.FirstImageUrl,
                    opt => opt.MapFrom(src => src.FirstImageUrl))
           .ForMember(dest => dest.PlaceRegionId,
                    opt => opt.MapFrom(src => src.PlaceRegionId))
           .ForMember(dest => dest.PlaceCityId,
                    opt => opt.MapFrom(src => src.PlaceCityId))
           .ForMember(dest => dest.TransmissionTypeId,
                    opt => opt.MapFrom(src => src.TransmissionTypeId))
           .ForMember(dest => dest.EngineTypeId,
                    opt => opt.MapFrom(src => src.EngineTypeId))
           .ForMember(dest => dest.BodyTypeId,
                    opt => opt.MapFrom(src => src.BodyTypeId));
  }
}
