using CleanArchitecture.CorePackages.Persistance.Repositories;

public class Car : Entity<Guid>
{
    public Guid ModelId { get; set; }
    public string Name { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindexScore { get; set; }
    public CarState CarState { get; set; }

    public virtual Model? Model { get; set; }

    public Car()
    {
        // Name = string.Empty;
    }

    public Car(Guid id,Guid modelId,CarState carState,int kilometer,short modelYear ,string plate,short minFindexScore):this()
    {
        Id = id;
        ModelId = modelId;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindexScore = minFindexScore;
        CarState = carState;
    }
    
}