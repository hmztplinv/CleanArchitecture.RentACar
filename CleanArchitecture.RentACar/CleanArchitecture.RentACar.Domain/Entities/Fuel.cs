using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Fuel:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; } // yakıtın birden fazla modeli var

    public Fuel()
    {
        Models = new HashSet<Model>(); // HashSet oluşturmamın sebebi birden fazla modeli olması
    }

    public Fuel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}