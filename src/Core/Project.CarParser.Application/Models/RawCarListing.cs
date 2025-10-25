namespace Project.CarParser.Application.Models;

public class RawCarListing
{
  // Основная информация
  public string? Title { get; set; }
  public string? Url { get; set; }
  public string FullUrl => $"https://cars.av.by{Url}";

  // Цены
  public string? PricePrimary { get; set; }
  public string? PriceSecondary { get; set; }

  // Параметры автомобиля
  public string? Year { get; set; }
  public string? Transmission { get; set; }
  public string? EngineVolume { get; set; }
  public string? FuelType { get; set; }
  public string? Mileage { get; set; }
  public string? BodyType { get; set; }

  // Дополнительная информация
  public string? Location { get; set; }
  public string? Date { get; set; }

  // Бейджи и статусы
  public bool HasVin { get; set; }

  // Фотографии
  public string? FirstImageUrl { get; set; }
}
