using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_reservation_system_individual_auth.middleware;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.Validators;
using cinema_reservation_system_individual_auth.models.worker;
using cinema_reservation_system_individual_auth.Services;
using cinema_reservation_system_individual_auth.Services.admin;
using cinema_reservation_system_individual_auth.Services.worker;
using cinema_reservation_system_individual_auth.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace cinema_reservation_system_individual_auth
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
            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);
            //services.AddScoped<ErrorHandlingMiddleware>();
            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            services.AddAuthorization();
            services.AddControllers().AddFluentValidation();
            services.AddDbContext<CinemaDbContext>();
            services.AddScoped<CinemaSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAdminAccountService, AdminAccountService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterAdminDto>, RegisterUserDtoValidator>();


            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IValidator<CreateWorkerDto>, CreateWorkerDtoValidator>();

            
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IValidator<UpdateRoomDto>, UpdateRoomDtoValidator>();
            services.AddScoped<IValidator<CreateRoomDto>, CreateRoomDtoValidator>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IValidator<UpdateMovieDto>, UpdateMovieDtoValidator>();
            services.AddScoped<IValidator<CreateMovieDto>, CreateMovieDtoValidator>();

            services.AddScoped<ISeanceService, SeanceService>();
            services.AddScoped<IValidator<UpdateSeanceDto>, UpdateSeanceDtoValidator>();
            services.AddScoped<IValidator<CreateSeanceDto>, CreateSeanceDtoValidator>();

            services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CinemaSeeder seeder)
        {
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema Reservation System API");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
