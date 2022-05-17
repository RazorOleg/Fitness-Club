using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using API;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterModule<ControllerModule>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<MainWindow>();
                mainWindow.Show();
                base.OnStartup(e);
            }
        }
    }
}
