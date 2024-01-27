using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);
        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        //builder.HasData(_seeds);
    }

    // private IEnumerable<OperationClaim> _seeds
    // {
    //     get
    //     {
    //         int id = 0;
    //         yield return new OperationClaim
    //         {
    //             Id = ++id,
    //             Name = "Admin",
    //         };

    //         IEnumerable<Type> featureOperationClaimTypes= Assembly
    //             .GetAssembly(typeof(ApplicationServiceRegistration))!
    //             .GetTypes()
    //             .Where(
    //                 type =>
    //                     (type.Namespace?.Contains("Features")==true) &&
    //                     (type.Namespace?.Contains("Constants")==true) &&
    //                     type.IsClass &&
    //                     type.Name.EndsWith("OperationClaims")
    //             );
    //         foreach (Type featureOperationClaimType in featureOperationClaimTypes)
    //         {
    //             FieldInfo[] typeFields = featureOperationClaimType.GetFields(BindingFlags.Public | BindingFlags.Static);
    //             IEnumerable<string> typeFieldValues = typeFields.Select(field => field.GetValue(null)!.ToString()!);

    //             IEnumerable<OperationClaim> featureOperationClaimsToAdd = typeFieldValues.Select(
    //                 value => new OperationClaim
    //                 {
    //                     Id = ++id,
    //                     Name = value,
    //                 }
    //             );
    //             foreach (OperationClaim featureOperationClaim in featureOperationClaimsToAdd)
    //             {
    //                 yield return featureOperationClaim;
    //             }
    //         }
    //     }
    // }
}