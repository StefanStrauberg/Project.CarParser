namespace Project.CarParser.Persistence.Configuration;

internal class CarListingConfiguration : BaseEntityConfiguration<CarListing>
{
       public override void Configure(EntityTypeBuilder<CarListing> builder)
       {
              base.Configure(builder);

              builder.Property(c => c.Title).IsRequired().HasMaxLength(150);
              builder.Property(c => c.Url).IsRequired().HasMaxLength(200);
              builder.HasIndex(c => c.Url).IsUnique();
              builder.Property(c => c.PricePrimary).IsRequired();
              builder.Property(c => c.PriceSecondary).IsRequired();
              builder.Property(c => c.Year).IsRequired();
              builder.Property(c => c.EngineVolume).IsRequired();
              builder.Property(c => c.Mileage).IsRequired();
              builder.Property(c => c.PublishDate).IsRequired();
              builder.Property(c => c.HasVin).IsRequired();
              builder.Property(c => c.FirstImageUrl).HasMaxLength(300);

              builder.HasOne(c => c.PlaceRegion)
                     .WithMany()
                     .HasForeignKey(c => c.PlaceRegionId);

              builder.HasOne(c => c.PlaceCity)
                     .WithMany()
                     .HasForeignKey(c => c.PlaceCityId);

              builder.HasOne(c => c.TransmissionType)
                     .WithMany()
                     .HasForeignKey(c => c.TransmissionTypeId);

              builder.HasOne(c => c.EngineType)
                     .WithMany()
                     .HasForeignKey(c => c.EngineTypeId);

              builder.HasOne(c => c.BodyType)
                     .WithMany()
                     .HasForeignKey(c => c.BodyTypeId);
       }
}
