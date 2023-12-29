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
        // predicate ile request.Id ye göre brand getirilir.
        Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        // todo:validation
        brand= _mapper.Map(request, brand); // request ten gelen bilgiler brand nesnesine map edilir.
        await _brandRepository.UpdateAsync(brand); // brand nesnesi update edilir.
        UpdatedBrandCommandResponse response = _mapper.Map<UpdatedBrandCommandResponse>(brand); // brand nesnesi UpdatedBrandCommandResponse nesnesine map edilir.
        return response;
    }
}