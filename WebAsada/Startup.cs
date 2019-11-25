using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAsada.Data;
using WebAsada.Helpers;
using WebAsada.Interfaces;
using WebAsada.Repository;
using WebAsada.Services;

namespace WebAsada
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddTransient<ChargeRepository>();
            services.AddTransient<PersonTypeRepository>();
            services.AddTransient<EntityRepository>();
            services.AddTransient<MonthRepository>();
            services.AddTransient<MeasurementRepository>();
            services.AddTransient<EstateRepository>();
            services.AddTransient<IdentificationTypeRepository>();
            services.AddTransient<ReceiptRepository>();
            services.AddTransient<PersonRepository>();
            services.AddTransient<PersonsByEstateRepository>();
            services.AddTransient<CurrencyRepository>();
            services.AddTransient<ContractTypeRepository>();
            services.AddTransient<SupplierReporsitory>();
            services.AddTransient<ProductTypeRepository>();
            services.AddTransient<WaterMeterRepository>();
            services.AddTransient<ContractRepository>();
            services.AddTransient<ChargeTypeRepository>(); 
            

            services.AddTransient<ILoggedUserReader, LoggedUser>();
            services.AddTransient<IYesNoOptions, YesNoOptions>(); 

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            //var currentCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //currentCulture.NumberFormat.NumberDecimalSeparator = ".";
            //currentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            //currentCulture.NumberFormat.NumberGroupSeparator = " "; 
            //Thread.CurrentThread.CurrentCulture = currentCulture; 
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(new CultureInfo("es-CR")),
            //    SupportedCultures = new List<CultureInfo>
            //    {
            //        new CultureInfo("es-CR")
            //    },
            //    SupportedUICultures = new List<CultureInfo>
            //    {
            //        new CultureInfo("es-CR")
            //    }
            //});
             
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    } 
}
 