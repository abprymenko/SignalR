namespace Server.API
{
    #region Usings
    using Microsoft.AspNetCore;
    using Server.API.App_Start;
    using Server.API.Service;
    #endregion

    #region Program
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                      .UseContentRoot(Directory.GetCurrentDirectory())
                      .UseIISIntegration()
                      .UseStartup<Startup>()
                      .ConfigureServices(services => services.AddHostedService<APIService>())
                      .UseEnvironment(Environments.Development)
                      .CaptureStartupErrors(true);
    }
    #endregion
}