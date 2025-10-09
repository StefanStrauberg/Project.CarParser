namespace Project.CarParser.Persistence.Configuration;

public class PlaceCityConfiguration : BaseEntityConfiguration<PlaceCity>
{
  public override void Configure(EntityTypeBuilder<PlaceCity> builder)
  {
    base.Configure(builder);

    builder.Property(p => p.Name).IsRequired();
    builder.Property(p => p.Number).IsRequired();
  }
}
