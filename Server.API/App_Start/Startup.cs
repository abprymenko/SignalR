using Contracts;
using Microsoft.AspNetCore.SignalR;
using Server.API.Hubs;

namespace Server.API.App_Start
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(15);
            });
            services.AddRouting();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.UseDefaultFiles();
            appBuilder.UseStaticFiles();
            appBuilder.Use(async (context, next) =>
            {
                var hubContext = context.RequestServices
                                        .GetRequiredService<IHubContext<Chat, IChat>>();

                if (next != null)
                {
                    await next.Invoke();
                }
            });
            appBuilder.UseHttpsRedirection();
            appBuilder.UseRouting();
            appBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Chat>("/hubs/chat");
            });
        }
    }
}
