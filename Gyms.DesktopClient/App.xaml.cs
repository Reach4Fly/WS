using Microsoft.Extensions.DependencyInjection;
using Gyms.ApplicationServices.GetGymPointListUseCase;
using Gyms.ApplicationServices.Ports.Cache;
using Gyms.ApplicationServices.Repositories;
using Gyms.DesktopClient.InfrastructureServices.ViewModels;
using Gyms.DomainObjects;
using Gyms.DomainObjects.Ports;
using Gyms.InfrastructureServices.Cache;
using Gyms.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gyms.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<GymPoint>, DomainObjectsMemoryCache<GymPoint>>();
            services.AddSingleton<NetworkGymPointRepository>(
                x => new NetworkGymPointRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<GymPoint>>())
            );
            services.AddSingleton<CachedReadOnlyGymPointRepository>(
                x => new CachedReadOnlyGymPointRepository(
                    x.GetRequiredService<NetworkGymPointRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<GymPoint>>()
                )
            );
            services.AddSingleton<IReadOnlyGymPointRepository>(x => x.GetRequiredService<CachedReadOnlyGymPointRepository>());
            services.AddSingleton<IGetGymPointListUseCase, GetGymPointListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
