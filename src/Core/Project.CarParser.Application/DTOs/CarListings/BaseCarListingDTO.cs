namespace Project.CarParser.Application.DTOs.CarListings;

public class BaseCarListingDTO : IMapWith<CarListing>
{
  public string Title { get; set; } = string.Empty;
  public int Price { get; set; }
  public string? Description { get; set; }
  public string Url { get; set; } = string.Empty;
  public int ManufactureYear { get; set; }
  public decimal EngineDisplacement { get; set; }
  public DateTime PublishDate { get; set; }

  void IMapWith<CarListing>.Mapping(Profile profile)
  {
    profile.CreateMap<CarListing, BaseCarListingDTO>()
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
