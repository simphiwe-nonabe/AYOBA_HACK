using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.User;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<UserCreationModel, User>();
        }
    }
}