namespace Project.CarParser.Persistence.Configuration;

public class PlaceRegionConfiguration : BaseEntityConfiguration<PlaceRegion>
{
  public override void Configure(EntityTypeBuilder<PlaceRegion> builder)
  {
    base.Configure(builder);

    builder.Property(p => p.Name).IsRequired();
    builder.Property(p => p.Number).IsRequired();
  }
}
