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
        //Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken) alıp CreatedBrandCommandResponse dönecek.
        Brand brand = _mapper.Map<Brand>(request);
        brand.Id = Guid.NewGuid();

        // var result =await _brandRepository.AddAsync(brand);
        await _brandRepository.AddAsync(brand);
        CreatedBrandCommandResponse response = _mapper.Map<CreatedBrandCommandResponse>(brand);
        return response;
    }
}

