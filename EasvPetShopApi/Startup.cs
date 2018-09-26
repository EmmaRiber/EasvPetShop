using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pet.Menu.Core.ApplicationService;
using Pet.Menu.Core.ApplicationService.Services;
using Pet.Menu.Core.DomainService;
using PetShop.Menu.Infrastructure.Data;
using PetShop.Menu.Infrastructure.Data.Repositories;

namespace EasvPetShopApi
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<PetAppContext>(
            //    opt => opt.UseInMemoryDatabase("ThaDB")
            //    );

            if (_env.IsDevelopment())
            {
                services.AddDbContext<PetAppContext>(
                    opt => opt.UseSqlite("Data Source=PetApp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetAppContext>(
                    opt => opt
                    .UseSqlServer(_conf.GetConnectionString("DefaultConnection")));
            }
            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var PActx = scope.ServiceProvider.GetService<PetAppContext>();
                    DBInitializer.SeedDB(PActx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var PActx = scope.ServiceProvider.GetService<PetAppContext>();
                    PActx.Database.EnsureCreated();
                }
                    app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
