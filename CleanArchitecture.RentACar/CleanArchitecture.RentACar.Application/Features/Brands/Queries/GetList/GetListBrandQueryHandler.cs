using AutoMapper;
using MediatR;

public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQueryRequest, GetListResponse<GetListBrandListItemDto>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQueryRequest request, CancellationToken cancellationToken)
    {
        Paginate<Brand> brands = await _brandRepository.GetListAsync(
            index: request.PageRequest.PageNumber,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
        );

        GetListResponse<GetListBrandListItemDto> response = _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
        return response;
    }


}