using AutoMapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommandRequest>().ReverseMap();
        CreateMap<Brand, CreatedBrandCommandResponse>().ReverseMap();
        CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
        CreateMap<Brand, GetByIdBrandQueryResponse>().ReverseMap();
        CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
    }
}