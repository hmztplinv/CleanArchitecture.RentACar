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
        Paginate<Model> models = await _modelRepository.GetListAsync( // IModelRepository'de tanımlı olan GetListAsync metodu çağrılıyor.
             include: m => m.Include(x => x.Brand).Include(x => x.Fuel).Include(x => x.Transmission), //join ıle Brand,Fuel,Transmission tabloları alınıyor.
             index: request.PageRequest.PageNumber, // sayfa numarası
             size: request.PageRequest.PageSize // sayfa boyutu
         );

        var response = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models); // models nesnesi GetListResponse<GetListModelListItemDto> nesnesine dönüştürülüyor.
        return response;
    }
}