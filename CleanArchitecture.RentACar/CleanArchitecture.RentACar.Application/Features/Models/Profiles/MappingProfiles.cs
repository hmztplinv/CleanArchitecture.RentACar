using AutoMapper;

namespace CleanArchitecture.RentACar.Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, GetListModelListItemDto>().ReverseMap(); // Model -> GetListModelListItemDto
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap(); // Paginate<Model> -> GetListResponse<GetListModelListItemDto>
        }
    }
}