public class GetListModelListItemDto
{
    public Guid Id { get; set; }
    public string BrandName { get; set; } // join ile alınacak
    public string FuelName { get; set; }
    public string TransmissionName { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}
