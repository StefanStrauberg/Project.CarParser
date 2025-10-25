namespace Project.CarParser.CarListingScraper;

internal class ParsedListing
{
  public RawCarListing Listing { get; set; } = null!;
  public bool Success { get; set; }
  public string Error { get; set; } = string.Empty;
}
