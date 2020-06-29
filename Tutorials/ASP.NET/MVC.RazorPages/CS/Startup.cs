using AspNetCoreRazorPagesApplication.DataAccess;
using AspNetCoreRazorPagesApplication.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreRazorPagesApplication {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services
                .AddRazorPages()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            // Added lines begin.
            services
                .AddXpoDefaultUnitOfWork(true, options => options
                    .UseConnectionString(Configuration.GetConnectionString("InMemoryDataStore"))
                    .UseThreadSafeDataLayer(true)
                    .UseConnectionPool(false) // Remove this line if you use a database server like SQL Server, Oracle, PostgreSql etc.                    
                    .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema) // Remove this line if the database already exists.
                    .UseEntityTypes(typeof(Customer), typeof(Order)) // Pass all of your persistent object types to this method.
                );
            // Added lines end.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            //Added lines begin.
            app.UseXpoDemoData();
            //Added lines end.
        }
    }
}
