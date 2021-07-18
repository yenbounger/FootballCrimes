using FootballCrimes.API.Config;
using FootballData.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Postcode.Client;
using PoliceClient;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Text.RegularExpressions;

namespace FootballCrimes.API
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
            services.AddCors(opts =>
            {
                // would be more strict in reality - just configuring stricter cors manually on azure 
                opts.AddPolicy("default", new CorsPolicyBuilder().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().Build());
            });
            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            services.AddDbContext<FootballCrimesContext>(config =>
            {
                var connstring = Configuration.GetConnectionString("DefaultConnection");
                config.UseSqlServer(connstring);
            });
            services.AddSingleton<HttpClient>();
            services.AddTransient<FootballDataClient>();
            services.AddTransient<PostcodeClient>();
            services.AddTransient<PoliceDataClient>();
            services.Configure<ApiKeys>(Configuration.GetSection("ApiKeys"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FootballCrimes", Version = "v1" });
            });


            services.AddHostedService<DataInitialiser>();
        }

        private static string RemovePortFromConnectionString(string connStr)
        {
            string[] connArray = Regex.Split(connStr, ";");
            string connectionstring = null;
            for (int i = 0; i < connArray.Length; i++)
            {

                if (i == 1)
                {
                    string[] datasource = Regex.Split(connArray[i], ":");
                    connectionstring += datasource[0] + string.Format(";port={0};", datasource[1]);
                }
                else
                {
                    connectionstring += connArray[i] + ";";
                }
            }

            return connectionstring;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FootballCrimesContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballCrimes.API v1"));
            }

            //remove need for manual update database calls
            app.UseCors("default");

            dbContext.Database.Migrate();
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
