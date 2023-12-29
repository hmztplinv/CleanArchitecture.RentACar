using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Transmission : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; } // vitesin birden fazla modeli var

    public Transmission()
    {
        Models = new HashSet<Model>();
    }

    public Transmission(Guid id, string name):this()
    {
        Id = id;
        Name = name;
    }
}