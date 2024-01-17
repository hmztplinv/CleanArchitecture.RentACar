using MediatR;

public class DeleteBrandCommandRequest : IRequest<DeletedBrandCommandResponse>,ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;
    public string? CacheGroupKey => "GetBrands";
}