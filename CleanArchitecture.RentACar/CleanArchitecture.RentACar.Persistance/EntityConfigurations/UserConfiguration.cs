using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        
        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasOne(u => u.OtpAuthenticators);
        builder.HasOne(u => u.EmailAuthenticators);

        builder.HasData(getSeeds());
    }

    private IEnumerable<User> getSeeds()
    {
        List<User> users = new List<User>();

        HashingHelper.CreatePasswordHash(
            "q1w2e3r4", 
            passwordHash:out byte[] passwordHash, 
            passwordSalt:out byte[] passwordSalt
            );
        User adminUser=new()
        {
            Id=1,
            FirstName="Admin",
            LastName="AdminQtech",
            Email="admin@admin.com",
            Status=true,
            PasswordHash=passwordHash,
            PasswordSalt=passwordSalt,
        };
        User user=new()
        {
            Id=2,
            FirstName="User",
            LastName="UserQtech",
            Email="user@user.com",
            Status=true,
            PasswordHash=passwordHash,
            PasswordSalt=passwordSalt,
        };
        users.Add(adminUser);
        users.Add(user);

        return users.ToArray();
    }
}