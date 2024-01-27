
using Microsoft.EntityFrameworkCore;

public class RefreshTokenRepository : EfRepositoryBase<BaseDbContext, RefreshToken, int>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userId, int refreshTokenTTL)
    {
        List<RefreshToken> tokens = await Query()
            .AsNoTracking()
            .Where(rt => rt.UserId == userId && 
            rt.Revoked== null &&
            rt.Expires >= DateTime.UtcNow &&
            rt.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow)
            .ToListAsync();

        return tokens;
    }
}