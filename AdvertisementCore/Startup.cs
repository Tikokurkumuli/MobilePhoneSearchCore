using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementCore.Client;
using AdvertisementCore.Helper;
using AdvertisementCore.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static AdvertisementCore.Helper.ManufacturerHelper1;
using static AdvertisementCore.Helper.PhoneHelper;

namespace AdvertisementCore
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiOptions>(options => Configuration.GetSection(nameof(ApiOptions)).Bind(options));
            services.Configure<ApiOptions1>(options => Configuration.GetSection(nameof(ApiOptions1)).Bind(options));
            services.AddHttpClient<PhoneSearchClient>(conf =>
            {
                conf.BaseAddress = new Uri(Configuration["Client:PhoneSearchApiRootUrl"] ?? throw new ArgumentNullException("Client:PhoneSearchApiRootUrl", "Parameter not set in appsettings.json"));
            });
            services.AddScoped<IMobilePhoneApiHelper, MobilePhonesApiHelper>();
            services.AddScoped<IManufacturerApiHelper, ManufacturerHelper>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute("blog", "blog/{*article}",
                            defaults: new { controller = "MobilePhone", action = "Index" });
                routes.MapRoute("default", "{controller=MobilePhone}/{action=Index}");
            });

        }
    }
}
