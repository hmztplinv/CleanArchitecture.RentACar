using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

public class BrandRepository : EfRepositoryBase<BaseDbContext, Brand, Guid>, IBrandRepository
{
    public BrandRepository(BaseDbContext context) : base(context)
    {

    }
}