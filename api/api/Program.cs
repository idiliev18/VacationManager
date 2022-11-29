using api.Configurations;
using api.Contracts;
using api.Data;
using api.Data.Models;
using api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            var connectionString = builder.Configuration.GetConnectionString("APICourseConnectionString");
            builder.Services.AddDbContext<VacationManagerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<User>>("VacationManager")
                .AddEntityFrameworkStores<VacationManagerDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            builder.Services.AddScoped<IUsersManager, UsersManager>();
            builder.Services.AddScoped<ITeamsRepository, TeamsRepository>();
            builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                };
            });


            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
            });


            //// CORS
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAngularDevClient",
            //        b =>
            //        {
            //            b
            //                .WithOrigins("http://localhost:4200")
            //                .AllowAnyHeader()
            //                .AllowAnyMethod();
            //        });
            //});
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}