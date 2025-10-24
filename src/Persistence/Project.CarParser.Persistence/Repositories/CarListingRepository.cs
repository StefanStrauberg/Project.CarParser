namespace Project.CarParser.Persistence.Repositories;

public class CarListingRepository(IExistenceQueryRepository<CarListing> existenceQueryRepository,
                                  ICountRepository<CarListing> countRepository,
                                  IInsertRepository<CarListing> insertRepository,
                                  IDeleteRepository<CarListing> deleteRepository,
                                  IReplaceRepository<CarListing> replaceRepository,
                                  IBulkInsertRepository<CarListing> bulkInsertRepository,
                                  ApplicationDbContext context) : ICarListingRepository
{
  async Task<CarListing> IOneQueryRepository<CarListing>.GetOneShortAsync(ISpecification<CarListing> specification,
                                                                          CancellationToken cancellationToken)
  {
    var query = context.CarListings.AsNoTracking();
    query = query.ApplyIncludes(specification.IncludeChains);
    query = query.ApplyWhere(specification.Criterias);
    query = query.ApplySkip(specification.Skip);
    query = query.ApplyTake(specification.Take);

    return await query.FirstAsync(cancellationToken);
  }

  async Task<bool> IExistenceQueryRepository<CarListing>.AnyByQueryAsync(ISpecification<CarListing> specification,
                                                                         CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification, cancellationToken);

  async Task<int> ICountRepository<CarListing>.GetCountAsync(ISpecification<CarListing> specification,
                                                             CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification, cancellationToken);

  async Task<IEnumerable<CarListing>> IManyQueryRepository<CarListing>.GetManyShortAsync(ISpecification<CarListing> specification,
                                                                                         CancellationToken cancellationToken)
  {
    var query = context.CarListings.AsNoTracking();
    query = query.ApplyIncludes(specification.IncludeChains);
    query = query.ApplyWhere(specification.Criterias);
    query = query.ApplyOrderBy(specification.OrderBy, specification.OrderByDescending != null);
    query = query.ApplySkip(specification.Skip);
    query = query.ApplyTake(specification.Take);

    return await query.ToListAsync(cancellationToken);
  }

  void IInsertRepository<CarListing>.InsertOne(CarListing entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<CarListing>.DeleteOne(CarListing entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<CarListing>.ReplaceOne(CarListing entity)
    => replaceRepository.ReplaceOne(entity);

  public void InsertMany(IEnumerable<CarListing> entities)
    => bulkInsertRepository.InsertMany(entities);
}
