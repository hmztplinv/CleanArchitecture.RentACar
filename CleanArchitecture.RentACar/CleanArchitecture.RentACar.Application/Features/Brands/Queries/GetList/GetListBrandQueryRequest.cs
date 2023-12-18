using MediatR;

public class GetListBrandQueryRequest:IRequest<GetListResponse<GetListBrandListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
}