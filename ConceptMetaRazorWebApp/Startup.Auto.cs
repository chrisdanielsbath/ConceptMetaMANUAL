/****************************
 * Startup.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp
{
    /// <summary>
    /// Startup class for the ConceptMeta Razor Web App
    /// </summary>
    public partial class Startup
    {

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Instance Properties
        public IConfiguration Configuration { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // add cookie-style authentication middleware to the authentication pipeline, and nominate it as the scheme to be used
            services.AddAuthentication("ConceptMetaAuth")
                .AddCookie(
                    "ConceptMetaAuth",
                    options =>
                    {
                        options.Cookie.Name = "ConceptMetaAuth";
                        options.LoginPath = "/Account/Login";
                        options.AccessDeniedPath = "/Account/AccessDenied";
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    });

            // add RazorPages
            services.AddRazorPages();

            // add Controllers, and services needed for interaction with ConceptMetaDb
            services.AddControllers();
            services.AddDbContext<ConceptMetaDbModelsContext>();

            // add services needed for interaction with ConceptMetaDbDomainRepositories
            services.AddDbContext<ConceptMetaDbContext>();
            services.AddScoped<IConceptMetaDbUnitOfWork, ConceptMetaDbUnitOfWork>();
            services.AddScoped<IConceptMetaDbBlueprintUnitOfWork, ConceptMetaDbBlueprintUnitOfWork>();
            services.AddScoped<IConceptMetaDbDomainUnitOfWork, ConceptMetaDbDomainUnitOfWork>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(
            IApplicationBuilder app,
            IHostEnvironment env)
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
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        #endregion
    }
}
