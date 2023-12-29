using AutoMapper;

public class MappingProfiles : Profile // AutoMapper kütüphanesini kullanarak mapping işlemlerini yapar
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommandRequest>().ReverseMap(); 
        CreateMap<Brand, CreatedBrandCommandResponse>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommandRequest>().ReverseMap();
        CreateMap<Brand, UpdatedBrandCommandResponse>();
        CreateMap<Brand, DeleteBrandCommandRequest>().ReverseMap();
        CreateMap<Brand, DeletedBrandCommandResponse>().ReverseMap();
        CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
        CreateMap<Brand, GetByIdBrandQueryResponse>().ReverseMap();
        CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap(); 
        // Paginate sınıfı içerisindeki Brand listesini GetListBrandListItemDto listesine dönüştürür
    }
}