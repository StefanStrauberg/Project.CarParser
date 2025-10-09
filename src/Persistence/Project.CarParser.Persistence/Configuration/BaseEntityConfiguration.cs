namespace Project.CarParser.Persistence.Configuration;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
  public virtual void Configure(EntityTypeBuilder<T> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id)
           .ValueGeneratedOnAdd()
           .HasDefaultValueSql("gen_random_uuid()");

    builder.Property(e => e.CreatedAt)
           .HasDefaultValueSql("CURRENT_TIMESTAMP");

    builder.Property(e => e.UpdatedAt);
  }
}
