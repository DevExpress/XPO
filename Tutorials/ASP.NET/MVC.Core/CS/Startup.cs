using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XpoTutorial;

namespace AspNetCoreMvcApplication {
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services
                .AddMvc()
                .AddDxSampleModelJsonOptions();
            services
                .AddXpoDefaultUnitOfWork(true, options => options
                    .UseConnectionString(Configuration.GetConnectionString("ImMemoryDataStore"))
                    .UseThreadSafeDataLayer(true)
                    .UseConnectionPool(false) // Remove this line if you use a database server like SQL Server, Oracle, PostgreSql etc.                    
                    .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema) // Remove this line if the database already exists
                    .UseEntityTypes(typeof(Customer), typeof(Order)) // Pass all of your persistent object types to this method.
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //Added lines begin.
            app.UseXpoDemoData();
            //Added lines end.
        }
    }
}
