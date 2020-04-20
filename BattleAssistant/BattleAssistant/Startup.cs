using BattleAssistant.Hubs;
using DataLayer.Entites;
using DataLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BattleAssistant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"), o => o.MigrationsAssembly("DataLayer.Migrations")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();
            services.AddSignalR();
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<DataContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("DataLayer.Migrations")));

            services.AddAuthentication()
                .AddDiscord(options =>
                {
                    options.ClientId = Configuration["Discord:ClientID"];
                    options.ClientSecret = Configuration["Discord:ClientSecret"];
                });
            ConfigureOwnServices(services);
        }

        private void ConfigureOwnServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityManager, IdentityManager>();
            services.AddScoped<IViewModelFactory, ViewModelFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapHub<ConflictHub>("/conflictHub");
            });
        }
    }
}
