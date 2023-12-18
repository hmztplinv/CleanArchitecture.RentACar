using AutoMapper;
using MediatR;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreatedBrandCommandResponse>
{

    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<CreatedBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        Brand brand = _mapper.Map<Brand>(request);
        brand.Id = Guid.NewGuid();

        await _brandRepository.AddAsync(brand);

        CreatedBrandCommandResponse response = _mapper.Map<CreatedBrandCommandResponse>(brand);
        return response;
    }
}

