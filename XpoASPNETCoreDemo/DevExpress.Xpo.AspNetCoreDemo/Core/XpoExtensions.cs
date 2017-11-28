using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace DevExpress.Xpo.Demo.Core {
    public static class CustomXpoExtensions {
        public static IServiceCollection AddXpoPooledDataLayer(this IServiceCollection serviceCollection, string connectionString) {
            return serviceCollection.AddSingleton<IDataLayer>(XpoHelper.CreatePooledDataLayer(connectionString));
        }
        public static IServiceCollection AddXpoDefaultUnitOfWork(this IServiceCollection serviceCollection) {
            return serviceCollection.AddScoped<UnitOfWork>((sp) => new UnitOfWork());
        }
        public static IServiceCollection AddXpoUnitOfWork(this IServiceCollection serviceCollection) {
            return serviceCollection.AddScoped<UnitOfWork>((sp) => new UnitOfWork(sp.GetService<IDataLayer>()));
        }
        public static IApplicationBuilder UseXpoDemoData(this IApplicationBuilder app) {
            using(var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                XpoHelper.CreateDemoData(() => scope.ServiceProvider.GetService<UnitOfWork>());
            }
            return app;
        }
    }
}