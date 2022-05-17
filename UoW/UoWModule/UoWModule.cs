using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DataBase;
using Repository;

namespace UoW
{
    public class UoWModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<FitnessContext>().SingleInstance();
            builder.RegisterType<ContextRepository<ClubEntity>>().As<IGenericRepository<ClubEntity>>().SingleInstance();
            builder.RegisterType<ContextRepository<ClubPassEntity>>().As<IGenericRepository<ClubPassEntity>>().SingleInstance();
            builder.RegisterType<ContextRepository<UserEntity>>().As<IGenericRepository<UserEntity>>().SingleInstance();
            builder.RegisterType<ContextRepository<WorkoutEntity>>().As<IGenericRepository<WorkoutEntity>>().SingleInstance();
        }
    }
}
