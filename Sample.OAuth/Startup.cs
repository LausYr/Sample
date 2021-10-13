using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Entities.Models;
using Sample.OAuth.Data;

namespace Sample.OAuth
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var ConfigurationConnection = Configuration.GetConnectionString("ConfigurationConnection");
            var DataConnection = Configuration.GetConnectionString("DataConnection");

            services.AddControllersWithViews();

            services.AddCors();
           
            services.AddDbContext<OAuthContext>(o => o.UseSqlServer(DataConnection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<OAuthContext>()
              .AddDefaultTokenProviders();


            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
                  .AddDeveloperSigningCredential() // AddSigningCredentials and provide a valid certificate
                  .AddAspNetIdentity<ApplicationUser>()
                  .AddConfigurationStore(opt =>
                  {
                      opt.ConfigureDbContext = c => c.UseSqlServer(ConfigurationConnection,
                          sql => sql.MigrationsAssembly(migrationAssembly));
                  })
                  .AddOperationalStore(opt =>
                  {
                      opt.ConfigureDbContext = o => o.UseSqlServer(ConfigurationConnection,
                          sql => sql.MigrationsAssembly(migrationAssembly));
                  });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();   
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<OAuthContext>();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}