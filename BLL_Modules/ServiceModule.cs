using Autofac;
using UoW;

namespace BLL
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClubsService>().As<IService<Club>>().SingleInstance();
            builder.RegisterType<UsersService>().As<IService<User>>().SingleInstance(); ;
            builder.RegisterType<WorkoutsService>().As<IService<Workout>>().SingleInstance();
            builder.RegisterType<ClubsPassService>().As<IService<ClubPass>>().SingleInstance();
            builder.RegisterModule<UoWModule>();
            builder.RegisterModule<MappingModule>();
        }
    }
}
