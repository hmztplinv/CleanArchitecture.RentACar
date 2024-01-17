using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Transmission : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; } // vitesin birden fazla modeli var

    public Transmission()
    {
        Models = new HashSet<Model>(); //neden hashset? cunku hashset tekrar eden degerleri almaz ve performans acisindan daha iyidir.
    }

    public Transmission(Guid id, string name):this()
    {
        Id = id;
        Name = name;
    }
}