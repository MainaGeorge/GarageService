using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SparkAuto.EmailServices;
using SparkAuto.Models;

namespace SparkAuto
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
            var emailConfigurations = Configuration.GetSection("EmailConfigurations")
                .Get<EmailConfigurations>();

            services.AddSingleton(emailConfigurations);

            services.AddScoped<IEmailSender, EmailSender>();


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;

                })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication()
                .AddFacebook(fb =>
            {
                fb.AppId = Configuration.GetValue<string>("ExternalAuthentication:facebookAppId");
                fb.AppSecret = Configuration.GetValue<string>("ExternalAuthentication:facebookAppSecret");
            })
                .AddGoogle(google =>
            {
                google.ClientId = Configuration.GetValue<string>("ExternalAuthentication:googleClientId");
                google.ClientSecret = Configuration.GetValue<string>("ExternalAuthentication:googleClientSecret");
            });

            

            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
