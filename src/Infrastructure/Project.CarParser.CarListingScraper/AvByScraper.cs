namespace Project.CarParser.CarListingScraper;

internal class AvByScraper
{
  private readonly HttpClient _httpClient;
  private readonly AvByScraperConfig _config;

  public AvByScraper(HttpClient httpClient, AvByScraperConfig? config = null)
  {
    _httpClient = httpClient;
    _config = config ?? new AvByScraperConfig();

    // Настройка HttpClient
    _httpClient.DefaultRequestHeaders.Add("User-Agent",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
    _httpClient.DefaultRequestHeaders.Add("Accept",
        "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
    _httpClient.DefaultRequestHeaders.Add("Accept-Language", "ru-RU,ru;q=0.9,en;q=0.8");
  }

  public async Task<List<RawCarListing>> GetTodayListingsAsync(CancellationToken cancellationToken = default)
  {
    var listings = new List<RawCarListing>();
    int page = 1;

    // Параметры для Минская обл, частное лицо, сегодня
    var queryParams = new Dictionary<string, string>
    {
      ["place_region[0]"] = "1005",      // Минская область
      ["seller_type[0]"] = "1",          // Частное лицо
      ["creation_date"] = "10",          // Сегодня
      ["sort"] = "4",                    // Сортировка по новым обьявлениям
      ["page"] = page.ToString(),        // Страница
    };

    var url = BuildUrl(_config.BaseUrl, queryParams);

    Console.WriteLine($"Запрос к URL: {url}");

    try
    {
      var html = await DownloadHtmlWithRetryAsync(url, cancellationToken);
      listings = ParseListings(html);

      // Задержка между запросами
      await Task.Delay(_config.DelayBetweenRequestsMs, cancellationToken);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Ошибка при получении объявлений: {ex.Message}");
    }

    return listings;
  }

  async Task<string> DownloadHtmlWithRetryAsync(string url, CancellationToken cancellationToken)
  {
    for (int i = 0; i < _config.MaxRetries; i++)
    {
      try
      {
        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
          Console.WriteLine("Обнаружено ограничение запросов. Ожидание 30 секунд...");
          await Task.Delay(30000, cancellationToken);
          continue;
        }

        // Проверка на капчу или блокировку
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        if (content.Contains("captcha") || content.Contains("доступ временно ограничен"))
        {
          Console.WriteLine("Обнаружена капча или блокировка. Прерывание...");
          throw new Exception("Требуется обход капчи");
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync(cancellationToken);
      }
      catch (HttpRequestException ex) when (i < _config.MaxRetries - 1)
      {
        Console.WriteLine($"Попытка {i + 1} не удалась: {ex.Message}");
        await Task.Delay(2000 * (i + 1), cancellationToken);
      }
    }

    throw new Exception("Не удалось загрузить страницу после всех попыток");
  }

  static List<RawCarListing> ParseListings(string html)
  {
    var listings = new List<RawCarListing>();
    var doc = new HtmlDocument();
    doc.LoadHtml(html);

    // Поиск контейнеров с объявлениями (классы могут меняться!)
    var listingNodes = doc.DocumentNode.SelectNodes("//div[@class='listing-item__wrap']");

    if (listingNodes == null)
    {
      Console.WriteLine("Объявления не найдены. Возможно, изменилась структура страницы.");
      return listings;
    }

    foreach (var node in listingNodes)
    {
      try
      {
        var listing = ParseListing(node);
        if (listing != null)
          listings.Add(listing);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка парсинга объявления: {ex.Message}");
      }
    }

    return listings;
  }

  static RawCarListing? ParseListing(HtmlNode node)
  {
    var listing = new RawCarListing();
    var parser = new AvByDetailedParser();

    var result = AvByDetailedParser.ParseListing(node);

    if (result.Success)
    {
      var detailedListing = result.Listing;

      // Основная информация
      listing.Title = detailedListing.Title;
      listing.Url = detailedListing.Url;

      // Цены
      listing.PricePrimary = detailedListing.PricePrimary;
      listing.PricePrimary = detailedListing.PricePrimary;
      listing.PriceSecondary = detailedListing.PriceSecondary;

      // Параметры автомобиля
      listing.Year = detailedListing.Year;
      listing.Transmission = detailedListing.Transmission;
      listing.EngineVolume = detailedListing.EngineVolume;
      listing.FuelType = detailedListing.FuelType;
      listing.Mileage = detailedListing.Mileage;
      listing.BodyType = detailedListing.BodyType;

      // Дополнительная информация
      listing.Location = detailedListing.Location;
      listing.Date = detailedListing.Date;

      // Бейджи и статусы
      listing.HasVin = detailedListing.HasVin;

      // Фотографии
      listing.FirstImageUrl = detailedListing.FirstImageUrl;
    }

    return string.IsNullOrEmpty(listing.Title) ? null : listing;
  }

  static string BuildUrl(string baseUrl, Dictionary<string, string> parameters)
  {
    var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
    foreach (var param in parameters)
      query[param.Key] = param.Value;
    return $"{baseUrl}?{query}";
  }
}
