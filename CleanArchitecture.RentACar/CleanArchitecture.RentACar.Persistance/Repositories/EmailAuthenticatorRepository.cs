public class EmailAuthenticatorRepository : EfRepositoryBase<BaseDbContext, EmailAuthenticator, int>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}