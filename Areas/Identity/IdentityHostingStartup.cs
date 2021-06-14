using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FishingHunting.Areas.Identity.IdentityHostingStartup))]
namespace FishingHunting.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}