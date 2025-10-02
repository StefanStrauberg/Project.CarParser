namespace Project.CarParser.Persistence.Context;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
  : DbContext(options)
{
  public DbSet<CarListing> Clients { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfiguration(new CarListingConfiguration());
  }
}
