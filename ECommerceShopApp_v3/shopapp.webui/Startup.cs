using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using shopapp.business.Abstract;
using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;

namespace shopapp.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            //homecontrollerda iproduct tanımladık yani uygulama bunu çağırdığında efcore tanımlı olacak
            //services.AddScoped<IProductRepository, MysqlProductRepository>(); gibi..

            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();



            services.AddControllersWithViews();//razor pages değil mvc yi kullanacagımızı belirtiyoruz
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();//wwwroot klasörünün açılması için kullandık

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")
                ),
                RequestPath = "/modules"
            });//burada da node_modules klasörünü açtık

            if (env.IsDevelopment())//uygulama geliştirme yapısındayken dataseedi ekledik UYGULAMAYI YAYINLADIĞIMIZDA BURASI TRUE DEĞİL FALSE DEĞERİNİ GÖNDERİR
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admincategories",
                    pattern: "admin/categories",
                    defaults: new { controller = "Admin", action = "CategoryList" }
                );
                endpoints.MapControllerRoute(
                   name: "admincategorycreate",
                   pattern: "admin/categories/create",
                   defaults: new { controller = "Admin", action = "CreateCategory" }
               );

                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "EditCategory" }
                );

                endpoints.MapControllerRoute(
                    name: "adminproducts",
                    pattern: "admin/products",
                    defaults: new { controller = "Admin", action = "ProductList" }
                );

                endpoints.MapControllerRoute(
                   name: "adminproductcreate",
                   pattern: "admin/products/create",
                   defaults: new { controller = "Admin", action = "CreateProduct" }
               );

                endpoints.MapControllerRoute(
                    name: "adminproductedit",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "EditProduct" }
                );

                // endpoints.MapControllerRoute(
                //     name: "adminproductlist",
                //     pattern: "admin/products/{id?}",
                //     defaults: new { controller = "Admin", action = "EditProduct" }
                // );

                //localhost/search
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "Search" }
                );
                //localhost/about
                endpoints.MapControllerRoute(
                    name: "about",
                    pattern: "about",
                    defaults: new { controller = "Shop", action = "About" }
                );

                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern: "{urlName}",
                    defaults: new { controller = "Shop", action = "Details" }
                );

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{category?}",
                    defaults: new { controller = "Shop", action = "List" }
                );

                //burada kullanıcı products ya da home yazdığında ilgili route çağırılacak ayrıca product list metodunu çağırdığımızda products yazısı görünüyor
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "home",
                    defaults: new { controller = "Home", action = "Index" }
                );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
