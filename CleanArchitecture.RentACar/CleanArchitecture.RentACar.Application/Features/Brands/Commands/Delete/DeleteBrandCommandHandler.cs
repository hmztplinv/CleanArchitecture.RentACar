using AutoMapper;
using MediatR;

public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommandRequest, DeletedBrandCommandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<DeletedBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
    {
        Brand? brand=await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

        await _brandRepository.DeleteAsync(brand);
        DeletedBrandCommandResponse response=_mapper.Map<DeletedBrandCommandResponse>(brand);
        return response;
    }
}