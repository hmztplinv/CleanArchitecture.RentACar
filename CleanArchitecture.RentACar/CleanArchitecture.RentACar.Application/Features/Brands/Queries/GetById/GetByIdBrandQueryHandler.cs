using AutoMapper;
using MediatR;

public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;

    public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
    {
        Brand? brand= await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        GetByIdBrandQueryResponse response = _mapper.Map<GetByIdBrandQueryResponse>(brand);
        return response;
    }
}