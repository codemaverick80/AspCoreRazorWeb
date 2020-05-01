using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicStore.Database.Entities;
using MusicStore.Services.Contracts;
using MusicStore.Services.Repositories;
using MusicStore.Web.Extensions;

namespace MusicStore.Web
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
            services.AddControllersWithViews();
            services.AddRazorPages();

            //// Connect Ms SQL Server
            //services.AddDbContext<MusicStoreDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));


            //// Connect MySQL
            services.AddDbContext<MusicStoreDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DatabaseConnectionMySQL")));


            services.AddAutoMapper(typeof(Startup));

            //// Here all the repository services uses the MusicDbContext and GsDBContext is DbContext.
            //// that means we must register these services with scope that is equal to or shorter than DbContext (Scoped life time)
            //// we can not register with Singleton life time which is larger than DbContext life time.
            services.AddScoped<IAlbumRespository, AlbumRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();

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

            //// Exception Middleware Extension
            //app.ConfigureExceptionHandler();

            //// Custom Exception Middleware
            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
