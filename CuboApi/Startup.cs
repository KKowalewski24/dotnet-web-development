using AutoMapper;
using CuboCore.Mappers;
using CuboCore.Repositories.Buckets;
using CuboCore.Services.Buckets;
using CuboCore.Services.Items;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CuboApi {

    public class Startup {

        /*------------------------ FIELDS REGION ------------------------*/
        public IConfiguration Configuration { get; }

        /*------------------------ METHODS REGION ------------------------*/
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IBucketRepository, InMemoryBucketRepository>();
            services.AddScoped<IBucketService, BucketService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddSingleton<IMapper>(_ => AutoMapperConfig.InitializeMapper());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }

}
