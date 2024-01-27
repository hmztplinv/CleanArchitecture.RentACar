
using Microsoft.EntityFrameworkCore;

public class UserOperationClaimRepository : EfRepositoryBase<BaseDbContext,UserOperationClaim, int>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
    {
        var operationClaims = await Query()
            .AsNoTracking()
            .Where(uoc => uoc.UserId == userId)
            .Select(uoc => new OperationClaim
            {
                Id = uoc.OperationClaimId,
                Name = uoc.OperationClaim.Name
            })
            .ToListAsync();
        
        return operationClaims;
    }
}