using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetListByDynamicModelQueryHandler : IRequestHandler<GetListByDynamicModelQueryRequest, GetListResponse<GetListByDynamicModelListItemDto>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByDynamicModelListItemDto>> Handle(GetListByDynamicModelQueryRequest request, CancellationToken cancellationToken)
    {
        Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
            request.DynamicQuery,
            include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
            index: request.PageRequest.PageNumber,
            size: request.PageRequest.PageSize
        );

        var response =_mapper.Map<GetListResponse<GetListByDynamicModelListItemDto>>(models);
        return response;
    }
}