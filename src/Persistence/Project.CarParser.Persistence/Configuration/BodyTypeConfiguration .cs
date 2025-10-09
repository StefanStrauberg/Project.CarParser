namespace Project.CarParser.Persistence.Configuration;

public class BodyTypeConfiguration : BaseEntityConfiguration<BodyType>
{
  public override void Configure(EntityTypeBuilder<BodyType> builder)
  {
    base.Configure(builder);

    builder.Property(b => b.Name).IsRequired();
    builder.Property(b => b.Number).IsRequired();
  }
}
