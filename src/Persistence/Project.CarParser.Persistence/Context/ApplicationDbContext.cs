namespace Project.CarParser.Persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
  : IdentityDbContext<User>(options)
{
  public DbSet<CarListing> CarListings { get; set; }
  public DbSet<PlaceRegion> PlaceRegions { get; set; }
  public DbSet<PlaceCity> PlaceCities { get; set; }
  public DbSet<TransmissionType> TransmissionTypes { get; set; }
  public DbSet<EngineType> EngineTypes { get; set; }
  public DbSet<BodyType> BodyTypes { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    builder.ApplyConfiguration(new CarListingConfiguration());
    builder.ApplyConfiguration(new PlaceRegionConfiguration());
    builder.ApplyConfiguration(new PlaceCityConfiguration());
    builder.ApplyConfiguration(new TransmissionTypeConfiguration());
    builder.ApplyConfiguration(new EngineTypeConfiguration());
    builder.ApplyConfiguration(new BodyTypeConfiguration());
  }

}
