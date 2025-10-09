namespace Project.CarParser.Persistence.Configuration;

internal class CarListingConfiguration : BaseEntityConfiguration<CarListing>
{
       public override void Configure(EntityTypeBuilder<CarListing> builder)
       {
              base.Configure(builder);

              builder.Property(c => c.Title).IsRequired();
              builder.Property(c => c.Price).IsRequired();
              builder.Property(c => c.Description);
              builder.Property(c => c.Url).IsRequired();
              builder.Property(c => c.ManufactureYear).IsRequired();
              builder.Property(c => c.EngineDisplacement).IsRequired();
              builder.Property(c => c.PublishDate).IsRequired();

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
