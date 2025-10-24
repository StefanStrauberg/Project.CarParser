namespace Project.CarParser.Application.Features.Scrapper;

public record ScrapFreshCarListingsCommand : ICommand<Unit>;

internal class ScrapFreshCarListingsCommandHandler(ICarListingScrapper scrapper)
  : ICommandHandler<ScrapFreshCarListingsCommand, Unit>
{
  public async Task<Unit> Handle(ScrapFreshCarListingsCommand request, CancellationToken cancellationToken)
  {
    var carListings = await scrapper.GetTodayListingsAsync(cancellationToken);

    return Unit.Value;
  }
}
