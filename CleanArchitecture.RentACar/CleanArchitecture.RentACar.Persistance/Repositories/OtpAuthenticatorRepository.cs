public class OtpAuthenticatorRepository : EfRepositoryBase<BaseDbContext, OtpAuthenticator, int>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}