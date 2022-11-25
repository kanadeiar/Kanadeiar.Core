namespace Wpf;

public partial class App : Application
{
    private static IHost? __Hosting;
    public static IHost Hosting => __Hosting
        ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
    /// <summary> 
    /// Сервисы приложения 
    /// </summary>
    public static IServiceProvider Services => Hosting.Services;
    private static IHostBuilder CreateHostBuilder(string[] Args) => Host
       .CreateDefaultBuilder(Args)
       .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", true, true))
       .ConfigureLogging(opt => opt.AddConsole())
       .ConfigureServices(ConfigureServices);
    private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.Configure<Settings>(host.Configuration);
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<MainPageViewModel>();
    }
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        await Hosting.StartAsync().ConfigureAwait(false);
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        using (Hosting)
        {
            base.OnExit(e);
            await Hosting.StopAsync().ConfigureAwait(false);
        }
    }
}

