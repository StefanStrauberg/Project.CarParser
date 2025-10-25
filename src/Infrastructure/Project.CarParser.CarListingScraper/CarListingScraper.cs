namespace Project.CarParser.CarListingScraper;

internal class CarListingScraper : ICarListingScraper
{
  async Task<IEnumerable<RawCarListing>> ICarListingScraper.GetFreshRawCarListingsAsync(CancellationToken cancellationToken)
  {
    var handler = new HttpClientHandler
    {
      UseCookies = true,
      AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
    };
    using var httpClient = new HttpClient(handler);
    var config = new AvByScraperConfig
    {
      DelayBetweenRequestsMs = 5000,
    };
    var scraper = new AvByScraper(httpClient, config);
    var listings = await scraper.GetTodayListingsAsync(cancellationToken);

    return listings;
  }
}
