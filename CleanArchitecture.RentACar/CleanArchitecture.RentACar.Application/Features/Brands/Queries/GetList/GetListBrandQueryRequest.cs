using MediatR;

public class GetListBrandQueryRequest:IRequest<GetListResponse<GetListBrandListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    // sayfalama bilgisi için.
    // bu yapı tüm sorgularda kullanılacak. bu yüzde CorePackages tarafında proje olusturduk
}