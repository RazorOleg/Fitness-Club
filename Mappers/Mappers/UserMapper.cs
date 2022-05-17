using API;
using AutoMapper;
using BLL;
using DataBase;

namespace Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
