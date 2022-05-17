using API;
using AutoMapper;
using BLL;
using DataBase;

namespace Mappers
{
    public class WorkoutMapper : Profile
    {
        public WorkoutMapper()
        {
            CreateMap<Workout, WorkoutEntity>().ReverseMap();
            CreateMap<Workout, WorkoutModel>().ReverseMap();
        }
    }
}
