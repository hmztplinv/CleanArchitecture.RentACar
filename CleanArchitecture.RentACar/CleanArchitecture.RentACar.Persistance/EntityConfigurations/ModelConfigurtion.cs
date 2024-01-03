using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Name).HasColumnName("Name").IsRequired();
        builder.Property(m => m.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(m => m.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(m => m.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(m => m.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(m => m.ImageUrl).HasColumnName("ImageUrl").IsRequired();

        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: m => m.Name, name: "UK_Models_Name").IsUnique(); // aynı isimde model oluşturulamaz

        builder.HasOne(m => m.Brand).WithMany(b => b.Models).HasForeignKey(m => m.BrandId); // bir modelin bir markası olabilir
        builder.HasOne(m => m.Fuel).WithMany(f => f.Models).HasForeignKey(m => m.FuelId); // bir modelin bir yakıtı olabilir
        builder.HasOne(m => m.Transmission).WithMany(t => t.Models).HasForeignKey(m => m.TransmissionId); // bir modelin bir vitesi olabilir

        builder.HasMany(m => m.Cars); // bir modelin birden fazla arabası olabilir

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue); // silinmiş olanları filtreleme
    }
}