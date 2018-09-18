using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pet.Menu.Core.ApplicationService;
using Pet.Menu.Core.ApplicationService.Services;
using Pet.Menu.Core.DomainService;
using PetShop;
using PetShop.Menu.Infrastructure.Data;
using PetShop.Menu.Infrastructure.Data.Repositories;

namespace EasvPetShopApi
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
            //services.AddDbContext<PetAppContext>(
            //    opt => opt.UseInMemoryDatabase("ThaDB")
            //    );

            services.AddDbContext<PetAppContext>(
                opt => opt.UseSqlite("Data Source=PetAppContext.db"));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            //services.AddScoped<IPrinter, Printer>();

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
                app.UseHsts();
            }
            app.UseMvc();
        }
    }
}
