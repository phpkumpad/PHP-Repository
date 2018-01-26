using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PHP.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace PHP
{
    public class Startup
    {

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PHP_SandboxContext>(
                options => options.UseSqlServer(Configuration["Data:PHP_Sandbox:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(
                options => options.UseSqlServer(Configuration["Data:PhpIdentity:ConnectionString"]));


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IMemberRepository, EFMemberRepository>();
            services.AddTransient<IMemberPcpRepository, EFMemberPcpRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();


        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            IdentitySeedData.EnsurePopulated(app);
            // adding test 2
            app.UseMvc(routes =>
            {

                // Branch 1
                routes.MapRoute(
                    
                    name: null,
                    template: "Membership",
                    defaults: new {controller = "Membership", action = "Index"}
               );


                routes.MapRoute(
                    name: null,
                    template: "{pcp}/Page{memberPage:int}",
                    defaults: new {controller = "Member", action = "List"}
                );

                routes.MapRoute(
                    name: null, 
                    template: "Page{memberPage:int}",
                    defaults: new {controller = "Member", action = "List", memberPage = 1});

                routes.MapRoute(
                    name: null,
                    template: "{pcp}",
                    defaults: new { controller = "Member", action = "List", memberPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Member", action = "List", memberPage = 1 });

                routes.MapRoute(
                    name: null, 
                    template: "{controller}/{action}/{id?}");
            });


        }
    }
}
