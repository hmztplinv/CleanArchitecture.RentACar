using MediatR;

public class GetListModelQueryRequest : IRequest<GetListResponse<GetListModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}