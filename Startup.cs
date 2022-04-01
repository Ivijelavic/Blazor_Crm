using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlazorSliders;
using CrmExpert.Data;
using CrmExpert.DbLayer;
using CrmExpert.Model;
using CrmExpert.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CrmExpert
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

  

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContextPool<OrbisDbContext>(
            //options => options.UseSqlServer(Configuration.GetConnectionString("OrbisConnection")));
            //services.AddDbContext<OrbisDbContext>(
            //ServiceLifetime.Transient,
            //options => options.UseSqlServer(Configuration.GetConnectionString("OrbisConnection")));

            services.AddDbContext<OrbisDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrbisDbConnection")));          
            services.AddDbContext<MRManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MRManagemebtConnection")));
            services.AddDbContext<OrbisContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrbisConnection")));
            //var builder = new ContainerBuilder();
            // builder.RegisterType<OrbisDbContext>().As<BaseContext>();
            // builder.RegisterType<MRManagementContext>().As<BaseContext>();
            // builder.Populate(services);

            services.AddTransient<MRManagementContext>();
            services.AddTransient<OrbisDbContext>();
            services.AddTransient<OrbisContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<OpportunityService>();
            services.AddScoped<BrowserService>();
            services.AddScoped<SliderInterop>();
            services.AddScoped<SelectedPonudaDobavljac>();
          
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
