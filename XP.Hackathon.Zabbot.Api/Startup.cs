using XP.Hackathon.Zabbot.Api.Filters;
using XP.Hackathon.Zabbot.Infrastructure.IoC;
using XP.Hackathon.Zabbot.Model.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace XP.Hackathon.Zabbot.Api
{
    public class Startup
    {
        public IConfigurationRoot _configuration { get; }
        public IConfiguration Configuration { get; }
        private const string SETTINGS = "Settings";
        readonly string MyAllowSpecificOrigins = "myAllowSpecificOrigins";

        public Startup(IHostingEnvironment env)
        {
#if DEBUG
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();
#else
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                          .AddJsonFile("appsettings.Release.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();
#endif

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var instructionSettings = new Settings();
            _configuration.Bind(SETTINGS, instructionSettings);
            services.AddSingleton(typeof(ISettings), (serviceProvider) => instructionSettings);

            AppSettings.Initialize();
            AppSettings.ConnectionString.Zabbot = _configuration["ConnectionString:Zabbot"];

            services.AddRazorPages();
            //services.AddCustomSwagger(Configuration);


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(new ExcetionFilter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            }).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("OpenAPISpec",
                    new OpenApiInfo()
                    {
                        Title = "XP Hackathon Zabbot",
                        Version = "v1",
                        Description = "ZabbotApi ecossistema",
                        TermsOfService = new Uri("https://Microbots.com.br/terms"),
                        Contact = new OpenApiContact()
                        {
                            Email = "webmaster@Microbots.com.br",
                            Name = "Microbots team",
                            Url = new Uri("https://www.Microbots.com")
                        }
                    });
                options.CustomSchemaIds(x => x.FullName);
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                                  \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            services.AddCors();

            var key = Encoding.ASCII.GetBytes(_configuration["TokenConfiguration:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            SimpleInjectorContainer.RegisterServices(services);
        }

       // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            //app.UseMiddleware(typeof(ExceptionFilterMiddleware));

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                string swaggerPath = string.IsNullOrWhiteSpace(s.RoutePrefix) ? "." : "..";
                s.SwaggerEndpoint($"{swaggerPath}/swagger/OpenAPISpec/swagger.json", "ZabbotApi API");
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
        }
    }
}
