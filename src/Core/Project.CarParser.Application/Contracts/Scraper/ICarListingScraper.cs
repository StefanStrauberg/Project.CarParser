namespace Project.CarParser.Application.Contracts.Scraper;

public interface ICarListingScraper
{
  Task<IEnumerable<RawCarListing>> GetFreshRawCarListingsAsync(CancellationToken cancellationToken);
}
