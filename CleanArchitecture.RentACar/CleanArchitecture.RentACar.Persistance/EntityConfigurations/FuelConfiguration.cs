using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.Name).HasColumnName("Name").IsRequired();
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: f => f.Name, name: "UK_Fuels_Name").IsUnique(); // aynı isimde yakıt oluşturulamaz

        builder.HasMany(f => f.Models); // bir yakıtın birden fazla modeli olabilir

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue); // silinmiş olanları filtreleme
    }
}