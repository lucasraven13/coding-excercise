using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProductsApi.BL.Services;
using ProductsApi.BL.Interfaces;
using ProductsApi.DAL;
using ProductsApi.DAL.Intrefaces;
using ProductsApi.DAL.Repositories;
using ProductsApi.BL.Profiles;
using AutoMapper;
using ProductsApi.Middlewares;

namespace ProductsApi
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
            services.AddDbContextPool<DataContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductRecordProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ErrorMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
