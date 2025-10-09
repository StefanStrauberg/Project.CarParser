namespace Project.CarParser.Persistence.Configuration;

public class TransmissionTypeConfiguration : BaseEntityConfiguration<TransmissionType>
{
  public override void Configure(EntityTypeBuilder<TransmissionType> builder)
  {
    base.Configure(builder);

    builder.Property(t => t.Name).IsRequired();
    builder.Property(t => t.Number).IsRequired();
  }
}
