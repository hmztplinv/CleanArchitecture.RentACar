using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; } // appsettings.json dosyasını okumak için
    public DbSet<Brand> Brands { get; set; }
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