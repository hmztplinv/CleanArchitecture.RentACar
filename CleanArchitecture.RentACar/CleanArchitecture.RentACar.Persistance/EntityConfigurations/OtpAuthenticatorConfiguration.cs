using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OtpAuthenticatorConfiguration : IEntityTypeConfiguration<OtpAuthenticator>
{
    public void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
    {
        builder.ToTable("OtpAuthenticators").HasKey(otp => otp.Id);
        builder.Property(otp => otp.Id).HasColumnName("Id").IsRequired();
        builder.Property(otp => otp.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(otp => otp.SecretKey).HasColumnName("SecretKey").IsRequired();
        builder.Property(otp => otp.IsVerified).HasColumnName("IsVerified").IsRequired();
        builder.Property(otp => otp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(otp => otp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(otp => otp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(otp => !otp.DeletedDate.HasValue);

        builder.HasOne(otp => otp.User);
    }
}