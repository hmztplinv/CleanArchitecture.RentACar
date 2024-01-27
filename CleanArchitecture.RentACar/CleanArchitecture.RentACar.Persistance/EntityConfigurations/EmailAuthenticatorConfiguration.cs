using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmailAuthenticatorConfiguration : IEntityTypeConfiguration<EmailAuthenticator>
{
    public void Configure(EntityTypeBuilder<EmailAuthenticator> builder)
    {
        builder.ToTable("EmailAuthenticators").HasKey(email => email.Id);
        builder.Property(email => email.Id).HasColumnName("Id").IsRequired();
        builder.Property(email => email.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(email => email.ActivationKey).HasColumnName("ActivationKey");
        builder.Property(email => email.IsVerified).HasColumnName("IsVerified").IsRequired();
        builder.Property(email => email.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(email => email.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(email => email.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(email => !email.DeletedDate.HasValue);

        builder.HasOne(email => email.User);
    }
}