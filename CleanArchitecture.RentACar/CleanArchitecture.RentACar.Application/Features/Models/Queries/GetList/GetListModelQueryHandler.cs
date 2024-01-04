using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetListModelQueryHandler : IRequestHandler<GetListModelQueryRequest, GetListResponse<GetListModelListItemDto>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQueryRequest request, CancellationToken cancellationToken)
    {
        Paginate<Model> models = await _modelRepository.GetListAsync(
             include: m => m.Include(x => x.Brand).Include(x => x.Fuel).Include(x => x.Transmission),
             index: request.PageRequest.PageNumber,
             size: request.PageRequest.PageSize
         );

        var response = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);
        return response;
    }
}