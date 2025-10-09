namespace Project.CarParser.Domain;

public class EngineType : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }
}