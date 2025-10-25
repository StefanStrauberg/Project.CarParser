namespace Project.CarParser.CarListingScraper;

internal partial class AvByDetailedParser
{
  public static ParsedListing ParseListing(HtmlNode node)
  {
    var listing = new RawCarListing();

    try
    {
      // 1. Заголовок и ссылка
      ParseTitleAndUrl(node, listing);

      // 2. Бейджи и статусы
      ParseBadges(node, listing);

      // 3. Параметры автомобиля
      ParseParameters(node, listing);

      // 4. Цены
      ParsePrices(node, listing);

      // 6. Информация о местоположении и дате
      ParseLocationAndDate(node, listing);

      // 7. Фотографии
      ParsePhotos(node, listing);

      return new ParsedListing { Listing = listing, Success = true };
    }
    catch (Exception ex)
    {
      return new ParsedListing
      {
        Listing = listing,
        Success = false,
        Error = ex.Message
      };
    }
  }

  static void ParseTitleAndUrl(HtmlNode node, RawCarListing listing)
  {
    var titleLink = node.SelectSingleNode(".//a[@class='listing-item__link']");
    if (titleLink != null)
    {
      listing.Title = WebUtility.HtmlDecode(titleLink.InnerText)?.Trim();
      listing.Url = titleLink.GetAttributeValue("href", "");
    }
  }

  static void ParseBadges(HtmlNode node, RawCarListing listing)
  {
    var badges = node.SelectNodes(".//div[contains(@class, 'badge')]");
    if (badges != null)
    {
      foreach (var badge in badges)
      {
        var badgeText = WebUtility.HtmlDecode(badge.InnerText)?.Trim();

        if (badgeText == "VIN") listing.HasVin = true;
      }
    }
  }

  static void ParseParameters(HtmlNode node, RawCarListing listing)
  {
    var paramsNode = node.SelectSingleNode(".//div[@class='listing-item__params']");
    if (paramsNode != null)
    {
      var paramDivs = paramsNode.SelectNodes("./div");
      if (paramDivs != null && paramDivs.Count >= 3)
      {
        // Год
        listing.Year = ExtractYear(paramDivs[0].InnerText);

        // Трансмиссия, объем двигателя, тип топлива, кузов
        ParseTechnicalParams(paramDivs[1].InnerText, listing);

        // Пробег
        listing.Mileage = ExtractMileage(paramDivs[2].InnerText);
      }
    }
  }

  static string ExtractYear(string text)
  {
    var match = MyYearRegex().Match(text);
    return match.Success ? match.Value : text.Replace("&nbsp;", " ").Trim();
  }

  static void ParseTechnicalParams(string text, RawCarListing listing)
  {
    var cleanText = WebUtility.HtmlDecode(text).Replace("&nbsp;", " ").Trim();
    var parts = SplitTechnicalParams(cleanText);

    if (parts.Count >= 4)
    {
      listing.Transmission = parts[0];   // "автомат"
      listing.EngineVolume = parts[1];   // "2,0 л"
      listing.FuelType = parts[2];       // "дизель"
      listing.BodyType = parts[3];       // "седан" - новый параметр
    }
    else
    {
      // Альтернативный парсинг если структура отличается
      listing.Transmission = ExtractTransmission(cleanText);
      listing.EngineVolume = ExtractEngineVolume(cleanText);
      listing.FuelType = ExtractFuelType(cleanText);
      listing.BodyType = ExtractBodyType(cleanText);
    }
  }

  static List<string> SplitTechnicalParams(string text)
  {
    var result = new List<string>();
    var cleanText = WebUtility.HtmlDecode(text).Replace("&nbsp;", " ").Trim();

    // Регулярка для объема двигателя: ищем "1,9 л", "2.0 л" и т.п.
    var engineVolumeRegex = MyУngineVolumeRegex();
    var engineMatch = engineVolumeRegex.Match(cleanText);

    if (engineMatch.Success)
    {
      var engineVolume = engineMatch.Value.Trim();
      var parts = cleanText.Replace(engineVolume, "[ENGINE]").Split(',');

      foreach (var part in parts)
      {
        var trimmed = part.Trim();
        if (trimmed == "[ENGINE]")
          result.Add(engineVolume);
        else
          result.Add(trimmed);
      }
    }
    else
      // fallback: просто разбиваем по запятой
      result = [.. cleanText.Split(',').Select(p => p.Trim())];

    return result;
  }

  static string ExtractTransmission(string text)
  {
    if (text.Contains("механика")) return "механика";
    if (text.Contains("автомат")) return "автомат";
    if (text.Contains("робот")) return "робот";
    if (text.Contains("вариатор")) return "вариатор";
    return text;
  }

  static string ExtractEngineVolume(string text)
  {
    var match = MyEngineVolumeRegex().Match(text);
    return match.Success ? match.Value : "";
  }

  static string ExtractFuelType(string text)
  {
    if (text.Contains("бензин")) return "бензин";
    if (text.Contains("дизель")) return "дизель";
    if (text.Contains("электро")) return "электро";
    if (text.Contains("гибрид")) return "гибрид";
    return "";
  }

  static string ExtractBodyType(string text)
  {
    var bodyTypes = new[]
    {
      "седан",
      "хэтчбек",
      "универсал",
      "внедорожник",
      "кроссовер",
      "купе",
      "кабриолет",
      "минивэн",
      "пикап",
      "лифтбек",
      "фургон"
    };

    foreach (var bodyType in bodyTypes)
    {
      if (text.Contains(bodyType))
        return bodyType;
    }

    return "";
  }

  static string ExtractMileage(string text)
  {
    var cleanText = WebUtility.HtmlDecode(text).Replace("&nbsp;", " ").Trim();
    var match = MyMileageRegex().Match(cleanText);
    return match.Success ? match.Value.Trim() : cleanText;
  }

  static void ParsePrices(HtmlNode node, RawCarListing listing)
  {
    var primaryPrice = node.SelectSingleNode(".//div[@class='listing-item__price-primary']");
    var secondaryPrice = node.SelectSingleNode(".//div[@class='listing-item__price-secondary']");

    if (primaryPrice != null)
      listing.PricePrimary = WebUtility.HtmlDecode(primaryPrice.InnerText)?.Replace("&nbsp;", " ").Trim();

    if (secondaryPrice != null)
      listing.PriceSecondary = WebUtility.HtmlDecode(secondaryPrice.InnerText)?.Replace("&nbsp;", " ").Trim();
  }

  static void ParseLocationAndDate(HtmlNode node, RawCarListing listing)
  {
    var locationNode = node.SelectSingleNode(".//div[@class='listing-item__location']");
    var dateNode = node.SelectSingleNode(".//div[@class='listing-item__date']");

    if (locationNode != null)
      listing.Location = WebUtility.HtmlDecode(locationNode.InnerText)?.Replace("&nbsp;", " ").Trim();

    if (dateNode != null)
      listing.Date = WebUtility.HtmlDecode(dateNode.InnerText)?.Replace("&nbsp;", " ").Trim();
  }

  static void ParsePhotos(HtmlNode node, RawCarListing listing)
  {
    var photoNodes = node.SelectNodes(".//img[@data-src]");
    if (photoNodes != null && photoNodes.Count > 0)
    {
      // Сохраняем первую фотографию
      var firstPhotoUrl = photoNodes[0].GetAttributeValue("data-src", "");
      if (!string.IsNullOrEmpty(firstPhotoUrl))
        listing.FirstImageUrl = firstPhotoUrl;
    }
  }

  [System.Text.RegularExpressions.GeneratedRegex(@"(\d{4})")]
  private static partial System.Text.RegularExpressions.Regex MyYearRegex();

  [System.Text.RegularExpressions.GeneratedRegex(@"(\d+[,.]?\d*)\s*л")]
  private static partial System.Text.RegularExpressions.Regex MyEngineVolumeRegex();

  [System.Text.RegularExpressions.GeneratedRegex(@"([\d\s ]+)\s*км")]
  private static partial System.Text.RegularExpressions.Regex MyMileageRegex();
  [GeneratedRegex(@"\d+[,.]\d+\s*л", RegexOptions.IgnoreCase, "en-US")]
  private static partial Regex MyУngineVolumeRegex();
}
