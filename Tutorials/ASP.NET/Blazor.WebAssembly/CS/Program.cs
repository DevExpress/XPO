using BlazorClientSideApplication.Models;

using DevExpress.Xpo.DB;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorClientSideApplication {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddXpoDefaultUnitOfWork(true, options =>
                options.UseConnectionString(WebApiDataStoreClient.GetConnectionString("https://localhost:44307/xpo/"))
                .UseConnectionPool(false)
                .UseThreadSafeDataLayer(false)
                .UseEntityTypes(typeof(Customer), typeof(Order)));

            builder.Services.AddDevExpressBlazor();

            await builder.Build().RunAsync();
        }
    }
}
