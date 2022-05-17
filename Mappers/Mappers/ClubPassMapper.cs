using API;
using AutoMapper;
using BLL;
using DataBase;

namespace Mappers
{
    public class ClubPassMapper : Profile
    {
        public ClubPassMapper()
        {
            CreateMap<ClubPass, ClubPassEntity>().ReverseMap();
            CreateMap<ClubPass, ClubPassModel>().ReverseMap();
        }
    }
}
