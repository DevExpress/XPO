using DevExpress.Xpo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorServerSideApplication {
    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder UseXpoDemoData(this IApplicationBuilder app) {
            using(var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                UnitOfWork uow = scope.ServiceProvider.GetService<UnitOfWork>();
                DemoDataHelper.Seed(uow);
            }
            return app;
        }
    }
}