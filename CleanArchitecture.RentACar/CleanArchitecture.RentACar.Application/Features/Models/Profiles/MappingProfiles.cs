using AutoMapper;

namespace CleanArchitecture.RentACar.Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, GetListModelListItemDto>()
                .ForMember(destinationMember: m => m.BrandName,memberOptions: opt => opt.MapFrom(m => m.Brand.Name))
                .ForMember(destinationMember: m => m.FuelName,memberOptions: opt => opt.MapFrom(m => m.Fuel.Name))
                .ForMember(destinationMember: m => m.TransmissionName,memberOptions: opt => opt.MapFrom(m => m.Transmission.Name))
                .ReverseMap(); // Model -> GetListModelListItemDto
            CreateMap<Model,GetListByDynamicModelListItemDto>()
                .ForMember(destinationMember: m => m.BrandName,memberOptions: opt => opt.MapFrom(m => m.Brand.Name))
                .ForMember(destinationMember: m => m.FuelName,memberOptions: opt => opt.MapFrom(m => m.Fuel.Name))
                .ForMember(destinationMember: m => m.TransmissionName,memberOptions: opt => opt.MapFrom(m => m.Transmission.Name))
                .ReverseMap(); // Model -> GetListByDynamicModelListItemDto
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap(); // Paginate<Model> -> GetListResponse<GetListModelListItemDto>
            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap(); // Paginate<Model> -> GetListResponse<GetListByDynamicModelListItemDto>
        }
    }
}