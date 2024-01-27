using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; } // appsettings.json dosyasını okumak için
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }

    public BaseDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated(); // database yoksa oluşturur,yani db nin var oldugundan emin ol
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Assembly.GetExecutingAssembly() : bu projedeki bütün classları bul
    }
}