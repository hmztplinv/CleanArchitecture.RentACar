using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: t => t.Name, name: "UK_Transmissions_Name").IsUnique(); // aynı isimde vites oluşturulamaz

        builder.HasMany(t => t.Models); // bir vitesin birden fazla modeli olabilir

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue); // silinmiş olanları filtreleme
    }
}