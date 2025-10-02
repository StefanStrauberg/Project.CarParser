namespace Project.CarParser.Persistence.Configuration;

internal class CarListingConfiguration : IEntityTypeConfiguration<CarListing>
{
  public void Configure(EntityTypeBuilder<CarListing> builder)
  {
    builder.ToTable("CarListings");

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
           .HasColumnName("Id")
           .HasColumnType("uuid")
           .HasDefaultValueSql("gen_random_uuid()");
    builder.Property(x => x.CreatedAt)
           .HasColumnName("CreatedAt")
           .HasColumnType("timestamptz")
           .HasDefaultValueSql("CURRENT_TIMESTAMP");
    builder.Property(x => x.UpdatedAt)
           .HasColumnName("UpdatedAt")
           .HasColumnType("timestamptz");
    builder.Property(x => x.Title)
           .HasColumnName("Title")
           .HasColumnType("text");
    builder.Property(x => x.Price)
           .HasColumnName("Price")
           .HasColumnType("integer");
    builder.Property(x => x.PlaceRegion)
           .HasColumnName("PlaceRegion")
           .HasColumnType("integer");
  }
}
