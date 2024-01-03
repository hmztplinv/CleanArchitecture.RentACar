using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

public class CarRepository : EfRepositoryBase<BaseDbContext, Car, Guid>, ICarRepository
{
    public CarRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }

}