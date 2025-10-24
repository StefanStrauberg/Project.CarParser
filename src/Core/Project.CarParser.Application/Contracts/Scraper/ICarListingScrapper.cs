namespace Project.CarParser.Application.Contracts.Scraper;

public interface ICarListingScrapper
{
  Task<List<CarListing>> GetTodayListingsAsync(CancellationToken cancellationToken);
}
