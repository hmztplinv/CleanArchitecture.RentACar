using MediatR;

public class GetListBrandQueryRequest:IRequest<GetListResponse<GetListBrandListItemDto>>, ICachableRequest, ILoggableRequest
{
    // sayfalama bilgisi için.
    // bu yapı tüm sorgularda kullanılacak. bu yüzde CorePackages tarafında proje olusturduk
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListBrandQueryRequest({PageRequest.PageNumber},{PageRequest.PageSize})"; 

    public bool BypassCache {get;}

    public TimeSpan? SlidingExpiration {get;}
    public string? CacheGroupKey => "GetBrands";
    
}