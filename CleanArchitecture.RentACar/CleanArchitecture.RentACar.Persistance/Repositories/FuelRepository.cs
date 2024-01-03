public class FuelRepository : EfRepositoryBase<BaseDbContext, Fuel, Guid>, IFuelRepository
{
    public FuelRepository(BaseDbContext context) : base(context)
    {
    }
}