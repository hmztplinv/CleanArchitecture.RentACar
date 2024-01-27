public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken, int>, IRepository<RefreshToken, int>
{
    Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userId,int refreshTokenTTL);
}