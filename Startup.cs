using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BusinessLayer.Extensions;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Traversal.CQRS.Handlers.DestinationHandlers;
using Traversal.Models;

namespace Traversal
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

            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIDQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();

            services.AddMediatR(typeof(Startup));

            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)
                .AddEntityFrameworkStores<Context>();

            services.AddHttpClient();

            services.DependencyRegistration();

            services.AddAutoMapper(typeof(Startup));

            services.CustomValidator();


            services.AddControllersWithViews().AddFluentValidation();

            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en");

                options.SupportedUICultures = new List<CultureInfo>
                    {
                        new ("en"),
                        new ("fr"),
                        new ("es"),
                        new ("el"),
                        new ("tr"),
                        new ("de")
                    };
                options.FallBackToParentUICultures = true;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                        new QueryStringRequestCultureProvider(), // URL'den kültürü al
                        new CookieRequestCultureProvider(), // Cookie üzerinden al
                        new AcceptLanguageHeaderRequestCultureProvider() // Tarayýcý dilini kullan
                    };
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>()?.Value;
            if (localizationOptions != null)
            {
                app.UseRequestLocalization(localizationOptions);
            }

            app.UseAuthorization();

            //var supportedCultures = new[] { "en", "fr", "es", "gr", "tr","de"};
            //var localizationOptions = new RequestLocalizationOptions()
            //.SetDefaultCulture(supportedCultures[4])
            //.AddSupportedCultures(supportedCultures)
            //.AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
