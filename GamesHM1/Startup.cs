using CoreBL;
using CoreBL.Profiles;
using CoreDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GamesHM1
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
            services.AddScoped<GameService>();
            services.AddScoped<IGameRepository, GamesInDBRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository, UsersInDBRepository>();
            services.AddScoped<SaleService>();
            services.AddScoped<ISaleRepository, SalesInDBRepository>();

            services.AddDbContext<EfCoreContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var assemblies = new[]
            {
               Assembly.GetAssembly(typeof(GamesProfile)),
               Assembly.GetAssembly(typeof(UsersProfile)),
               Assembly.GetAssembly(typeof(SalesProfile))
            };

            services.AddAutoMapper(assemblies);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
