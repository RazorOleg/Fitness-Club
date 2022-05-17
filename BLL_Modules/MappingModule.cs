using Autofac;
using AutoMapper;
using Mappers;

namespace BLL
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClubMapper>();
                cfg.AddProfile<ClubPassMapper>();
                cfg.AddProfile<UserMapper>();
                cfg.AddProfile<WorkoutMapper>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
