using GoldStore.Repository.Classes;
using GoldStore.Repository.Interfaces;
using GoldStore.Services.Classes;
using GoldStore.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoldStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<GoldStoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("GoldStore")));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<ICatalogService, CatalogService>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "catalog/{categorySlug}/{brandSlug}/page{page:int}",
                    defaults: new { controller = "Catalog", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "page{page:int}",
                    defaults: new
                    {
                        controller = "Catalog",
                        action = "Index",
                        productPage = 1
                    }
                );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "catalog/{categorySlug}/{brandSlug}",
                    defaults: new
                    {
                        controller = "Catalog",
                        action = "Index",
                        productPage = 1
                    }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Catalog}/{action=Index}/{id?}");
            });
        }
    }
}
