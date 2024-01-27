using AutoMapper;

namespace CleanArchitecture.RentACar.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile // AutoMapper kütüphanesini kullanarak mapping işlemlerini yapar
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserCommandRequest>().ReverseMap();
            CreateMap<User, CreateUserCommandResponse>().ReverseMap();
        }
    }
}