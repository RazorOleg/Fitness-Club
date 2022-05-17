using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL;

namespace API
{
    public class ControllerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClubsController>().As<IController<ClubModel>>().SingleInstance();
            builder.RegisterType<UsersController>().As<IController<UserModel>>().SingleInstance();
            builder.RegisterType<WorkoutsController>().As<IController<WorkoutModel>>().SingleInstance();
            builder.RegisterType<ClubsPassController>().As<IController<ClubPassModel>>().SingleInstance();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
