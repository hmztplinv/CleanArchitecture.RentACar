using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Model : Entity<Guid>
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public virtual Brand? Brand { get; set; } // modelim markası var
    public virtual Fuel? Fuel { get; set; } // modelim yakıtı var
    public virtual Transmission Transmission { get; set; } // modelim vitesi var
    public virtual ICollection<Car> Cars { get; set; } // modelin birden fazla araçları var

    public Model()
    {
        Cars = new HashSet<Car>();
    }

    // :this() ile parametresiz constructor'ı çağırıyoruz yani aşagıdaki çalıştıgında önce parametresiz constructor çalışacak
    public Model(Guid id,Guid brandId,Guid fuelId,Guid transmissionId, string name, decimal dailyPrice, string imageUrl):this()
    {
        Id = id;
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
    }
    
}