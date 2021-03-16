using Application.Core;
using Application.Handlers.Activities;
using Application.Interfaces;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _configuration)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
      });

      services.AddDbContext<DataContext>(opt =>
      {
        opt.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
        {
          policy
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .WithOrigins("http://localhost:3000");
        });
      });

      services.AddMediatR(typeof(List.Handler).Assembly);

      services.AddAutoMapper(typeof(MappingProfiles).Assembly);

      services.AddScoped<IUserAccessor, UserAccessor>();

      services.AddScoped<IPhotoAccessor, PhotoAccessor>();

      services.Configure<CloudinarySettings>(_configuration.GetSection("Cloudinary"));

      return services;
    }
  }
}