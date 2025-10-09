namespace Project.CarParser.Persistence.Configuration;

public class EngineTypeConfiguration : BaseEntityConfiguration<EngineType>
{
  public override void Configure(EntityTypeBuilder<EngineType> builder)
  {
    base.Configure(builder);

    builder.Property(e => e.Name).IsRequired();
    builder.Property(e => e.Number).IsRequired();
  }
}
