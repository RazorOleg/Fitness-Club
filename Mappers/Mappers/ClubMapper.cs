using API;
using AutoMapper;
using BLL;
using DataBase;

namespace Mappers
{
    public class ClubMapper : Profile
    {
        public ClubMapper()
        {
            CreateMap<Club, ClubEntity>().ReverseMap();
            CreateMap<Club, ClubModel>().ReverseMap();
        }
    }
}
