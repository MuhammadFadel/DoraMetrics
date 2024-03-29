using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DoraMetrics.Helpers;
using Integrations.GitlabServices;
using Integrations.GitlabServices.Services;
using Data;
using Data.Repos;
using SD = Helpers.ClientServices.SD;
using Integrations.JiraServices;
using Integrations.JiraServices.Services;

namespace DoraMetrics
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
            // Database Configuration
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
            services.AddControllersWithViews();

            // Gitlab Services Configurations
            SD.GitlabApiBase = Configuration["GitlabService:GitlabApiUrl"];
            SD.JiraApiBase = Configuration["JiraService:JiraApiUrl"];
            services.AddHttpClient<IProjectServices, ProjectServices>();            
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddHttpClient<IGroupServices, GroupServices>();
            services.AddScoped<IGroupServices, GroupServices>();
            services.AddScoped<IIssueServices, IssueServices>();

            services.AddScoped<IIssueEventRepo, IssueEventRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectRepo, ProjectRepo>();            
            services.AddScoped<IGroupRepo, GroupRepo>();            
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
