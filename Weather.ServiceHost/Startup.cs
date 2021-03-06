using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Weather.RA.DbContexts;
using Weather.RA.Interfaces;
using Weather.RA.MongoRepositories;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.AppStart;
using Weather.ServiceHost.Mappings;

namespace Weather.ServiceHost
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather.ServiceHost", Version = "v1" });
            });

            services.AddDbContext<SqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();

            services.Configure<WeatherApiSettings>(Configuration.GetSection("WeatherApiSettings"));

            services.Configure<MongoSettings>(Configuration.GetSection("MongoSettings"));

            services.AddMediatR(typeof(Startup));

            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather.ServiceHost v1"));
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
