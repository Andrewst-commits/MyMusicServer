using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server_nw.AuthorizationApplication;
using Server_nw.MusicApplication;
using Server_nw.MusicApplication.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.Core
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
            var connection = Configuration.GetConnectionString("AuthorizationDatabase_1");

            services.AddDbContext<AuthorizationDbContext>(options =>
                options.UseSqlServer(connection));

            connection = Configuration.GetConnectionString("MusicDatabase");

            services.AddDbContext<MusicServiceDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped<IAlbum, AlbumInMsSQlServerRepository>();
            services.AddScoped<ISong, SongInMsSQlServerRepository>();
            services.AddScoped<IBandService, BandService>();
            services.AddScoped<IListenerService, ListenerService>();
            services.AddScoped<IPerformerService, PerformerService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server_nw", Version = "v1" });
            })
             .ConfigureSwaggerGen(options =>
             {
                 var xmlPath = Path.Combine(AppContext.BaseDirectory, "Server_nw.xml");
                 options.IncludeXmlComments(xmlPath, true);

             });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server_nw v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



