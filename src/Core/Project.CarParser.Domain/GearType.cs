namespace Project.CarParser.Domain;

public class TransmissionType : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public int Number { get; set; }
}

