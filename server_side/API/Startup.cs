using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Handlers.Activities;
using API.Extensions;
using FluentValidation.AspNetCore;
using API.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using API.SignalR;

namespace API
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddControllers(opt =>
        {
          var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
          opt.Filters.Add(new AuthorizeFilter(policy));
        })
        .AddFluentValidation(config =>
        {
          config.RegisterValidatorsFromAssemblyContaining<Create>();
        });

      services.AddApplicationServices(_configuration);

      services.AddIdentityServices(_configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ExceptionMiddleware>();

      app.UseXContentTypeOptions();
      app.UseReferrerPolicy(opt => opt.NoReferrer());
      app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
      app.UseXfo(opt => opt.Deny());
      app.UseCsp(opt => opt
          .BlockAllMixedContent()
          .StyleSources(s => s.Self().CustomSources(
              "https://fonts.googleapis.com",
              "sha256-/epqQuRElKW1Z83z1Sg8Bs2MKi99Nrq41Z3fnS2Nrgk=",
              "sha256-2aahydUs+he2AO0g7YZuG67RGvfE9VXGbycVgIwMnBI=",
              "sha256-+oGcdj5BhO6SoiIGYIkPOMYi7d2h2Pp/bkJLBfYL+kk="
            ))
          .FontSources(s => s.Self().CustomSources(
              "https://fonts.gstatic.com", "data:"
              ))
          .FormActions(s => s.Self())
          .FrameAncestors(s => s.Self())
          .ImageSources(s => s.Self().CustomSources(
              "https://res.cloudinary.com",
              "https://www.facebook.com",
              "https://scontent.fgyd5-2.fna.fbcdn.net",
              "https://platform-lookaside.fbsbx.com",
              "https://scontent-lht6-1.xx.fbcdn.net",
              "data:"
            ))
          .ScriptSources(s => s.Self().CustomSources(
              "sha256-jhwwwF3J2qFo8IPNQN+eH3TSp17EKnIcY9r8yUVArU0=",
              "https://connect.facebook.net",
              "sha256-gPyFjQqVnFhkspP6KmXCEvyFS5W07G7V7W/bl5JNSog="
            ))
      );

      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
      }
      else
      {
        app.Use(async (context, next) =>
        {
          context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
          await next.Invoke();
        });
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseCors("CorsPolicy");

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapHub<ChatHub>("/chat");
        endpoints.MapFallbackToController("Index", "Fallback");
      });
    }
  }
}