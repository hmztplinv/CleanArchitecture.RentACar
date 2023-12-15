using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Brand:Entity<Guid>
{
    public string Name { get; set; }

    public Brand()
    {
        
    }

    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}