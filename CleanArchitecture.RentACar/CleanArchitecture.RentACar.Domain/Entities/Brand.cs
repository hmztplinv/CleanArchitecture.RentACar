using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Brand:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; } // markanın birden fazla modeli var

    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(Guid id, string name):this()
    {
        Id = id;
        Name = name;
    }
}