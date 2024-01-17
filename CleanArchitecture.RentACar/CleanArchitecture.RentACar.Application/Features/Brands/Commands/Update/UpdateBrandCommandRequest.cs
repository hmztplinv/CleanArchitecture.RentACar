using MediatR;

public class UpdateBrandCommandRequest: IRequest<UpdatedBrandCommandResponse>,ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CacheKey => "";

    public bool BypassCache => false;
    public string? CacheGroupKey => "GetBrands";
}