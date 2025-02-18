using IPTE.ITS.API.Swagger;
using IPTE.ITS.Aplicacion;
using IPTE.ITS.Infraestructura;
using IPTE.ITS.Infraestructura.Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using static CSharpFunctionalExtensions.Result;

namespace IPTE.ITS.API
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment) 
        {
            Configuration = configuration;
            Environment = environment;
        }

        public const string Origenesfront = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAplicacion();
            services.AddInfraestructura(Configuration, Environment);//Persistence

            //PERMITE CORS
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: Origenesfront, policy =>
            //    {
            //        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //    });
            //});

            services.AddHttpContextAccessor();
            
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();//Persistence

            services.AddControllers()
                .AddJsonOptions(X =>
                {
                    X.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    X.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                } 
                );

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMigrationsEndPoint();
            app.UseSwagger();
            app.UseSwaggerUI();
            
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHealthChecks("/Health");//Persistence

            app.UseRouting();

            //app.UseCors(Origenesfront);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
