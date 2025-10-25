namespace Project.CarParser.Application.DTOs.CarListings;

public class BaseCarListingDTO : IMapWith<CarListing>
{
  public string Title { get; set; } = string.Empty;
  public string Url { get; set; } = string.Empty;
  public string FullUrl => $"https://cars.av.by{Url}";
  public int PricePrimary { get; set; }
  public int PriceSecondary { get; set; }
  public int Year { get; set; }
  public double EngineVolume { get; set; }
  public int Mileage { get; set; }
  public DateTime PublishDate { get; set; }
  public bool HasVin { get; set; }
  public string? FirstImageUrl { get; set; }

  void IMapWith<CarListing>.Mapping(Profile profile)
  {
    profile.CreateMap<CarListing, BaseCarListingDTO>()
           .ForMember(dest => dest.Title,
                      opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Url,
                    opt => opt.MapFrom(src => src.Url))
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
                    opt => opt.MapFrom(src => src.FirstImageUrl));
  }
}
