namespace Project.CarParser.CarListingScraper;

internal class AvByScraperConfig
{
  public string BaseUrl { get; set; } = "https://cars.av.by/filter";
  public int DelayBetweenRequestsMs { get; set; } = 3000;
  public int MaxRetries { get; set; } = 3;
}
