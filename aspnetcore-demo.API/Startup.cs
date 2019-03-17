using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace aspnetcore_demo.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(op =>
            {
                op.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "aspnetcore-demo",
                        Version = "v1",
                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op =>
                {
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "",
                        ValidAudience = "",
                        IssuerSigningKey = new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(@"kzfSPDKwdx5KnyxtBTlwNW_IoqrpbaGRwaFNdqxQyv-
                                                                            WVIqeLKOGJVLmh4lRd4wUPmolq6CM7Bs4r1NRbAoZQZQui
                                                                            80YbqMGuymdw5NSlnMvoMHNdF2niiydKV5X2esajAZk6t1
                                                                            pu1Jf05TNIxQBO1aI8xnk4ttVIPXRDG47wKlTPwnvqpVX3l
                                                                            h5nwrG_A4fUj7KOslfysPbusORDePIQlnnCqkzURl3qanQz
                                                                            jku02kWxujqpujl3I1VpJ0zKc2ReeyVNoeKNG3WYi2eO8sY
                                                                            sDw8XtbkcY5mJW7dHeXSMYvzrFIWDbbxorb5LP0FtFbsgOf
                                                                            h8IYT4qzSL4BmUV17ag")), 
                            SecurityAlgorithms.HmacSha256Signature).Key

                    };
                });

            services.AddMediatR(AppDomain.CurrentDomain.Load("aspnetcore-demo.Domain"));
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "aspnetcore-demo");
            });
        }
    }
}
