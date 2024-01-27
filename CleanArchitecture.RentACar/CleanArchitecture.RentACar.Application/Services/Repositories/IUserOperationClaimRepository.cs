public interface IUserOperationClaimRepository: IAsyncRepository<UserOperationClaim,int>,IRepository<UserOperationClaim,int>
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
}