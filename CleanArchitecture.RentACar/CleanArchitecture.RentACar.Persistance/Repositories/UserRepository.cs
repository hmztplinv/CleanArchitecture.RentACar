public class UserRepository : EfRepositoryBase<BaseDbContext,User,int>, IUserRepository
{
    public UserRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}