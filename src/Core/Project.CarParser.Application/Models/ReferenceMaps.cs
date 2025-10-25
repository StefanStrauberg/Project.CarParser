namespace Project.CarParser.Application.Models;

public class ReferenceMaps(IReadOnlyDictionary<string, Guid> transmission,
                           IReadOnlyDictionary<string, Guid> engine,
                           IReadOnlyDictionary<string, Guid> body,
                           IReadOnlyDictionary<string, Guid> city,
                           IReadOnlyDictionary<string, Guid> region)
{
  public IReadOnlyDictionary<string, Guid> Transmission => transmission;
  public IReadOnlyDictionary<string, Guid> Engine => engine;
  public IReadOnlyDictionary<string, Guid> Body => body;
  public IReadOnlyDictionary<string, Guid> City => city;
  public IReadOnlyDictionary<string, Guid> Region => region;
}
