using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DevExpress.Xpo;
using DevExpress.Xpo.DB;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

using WebApiApplication.Helpers;

namespace WebApiApplication {
    public class Startup {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();


            // Configure XPO Data Store Service
            string connectionString;
            AutoCreateOption autoCreateOption = AutoCreateOption.SchemaAlreadyExists;
            if(HostingEnvironment.IsDevelopment()) {
                connectionString = Configuration.GetConnectionString("Dev");
                autoCreateOption = AutoCreateOption.DatabaseAndSchema;
            }
            else {
                connectionString = Configuration.GetConnectionString("Prod");
                connectionString = XpoDefault.GetConnectionPoolString(connectionString);
            }
            IDataStore dataStore = XpoDefault.GetConnectionProvider(connectionString, autoCreateOption);
            WebApiDataStoreService service = new WebApiDataStoreService(dataStore);
            services.AddSingleton(dataStore);
            services.AddSingleton(service);

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddCors(options =>
                options.AddPolicy("XPO", builder =>
                    builder.WithOrigins("https://localhost:44317")
                        .WithMethods("POST")
                        .WithHeaders("Content-Type")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseXpoDemoData();

        }
    }
}
