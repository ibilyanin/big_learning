using System.Windows;
using Common.Core.Abstractions;
using Common.Core.Extensions;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elang.Desktop.UI;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    static App()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();
        services.AddViews(typeof(App).Assembly);
        var serviceProvider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(serviceProvider);
    }
}
