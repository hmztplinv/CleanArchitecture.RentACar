using MediatR;

public class CreateBrandCommandRequest:IRequest<CreatedBrandCommandResponse>, ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string Name { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";
    // CreateBrandCommandRequest sen bir requestsin ve Name adında bir property'in var.
    // Dönüş olarak CreatedBrandCommandResponse döneceksin.
}