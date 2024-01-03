using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        
        builder.ToTable("Brands").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name,name:"UK_Brands_Name").IsUnique(); // aynı isimde marka oluşturulamaz
        builder.HasMany(b => b.Models); // bir markanın birden fazla modeli olabilir


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue); // silinmiş olanları filtreleme

    }
}