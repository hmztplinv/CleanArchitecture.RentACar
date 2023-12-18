using AutoMapper;
using MediatR;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdatedBrandCommandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

        brand= _mapper.Map(request, brand);
        await _brandRepository.UpdateAsync(brand);
        UpdatedBrandCommandResponse response = _mapper.Map<UpdatedBrandCommandResponse>(brand);
        return response;
    }
}