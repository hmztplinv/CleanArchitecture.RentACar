public class OperationClaimRepository: EfRepositoryBase<BaseDbContext,OperationClaim,int>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}