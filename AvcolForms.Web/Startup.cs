﻿/*
 * Licensed under the MIT License
 * Copyright (c) 2022 Bradley Grover
 */

using AvcolForms.Web.Initialization;
using AvcolForms.Web.ServiceConfigures;
using MudBlazor.Services;
using Serilog;

namespace AvcolForms.Web;

/// <summary>
/// Startup class to register application services and the HTTP Request Pipeline
/// </summary>
public sealed class Startup
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class
    /// </summary>
    /// <param name="configuration">The configuration used for the application</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }

    /// <summary>
    /// The configuration for our web application
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Configures and registers services for the web application
    /// </summary>
    /// <param name="services">The service collection to add services for dependency injection</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMudServices(configuration =>
        {
            configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
        });

        services.AddRazorPages();
        services.AddControllers();
        services.AddServerSideBlazor();

        services.AddApplicationOptions(Configuration);
        services.AddAuthorizationCore();

        services.AddDb(Configuration);
        services.AddSingletons(Configuration);
        services.AddScopedServices();
        services.AddTransientServices(Configuration);

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddTransient<IDataInitializor, DataInitializer>();
    }

    /// <summary>
    /// Configures the HTTP request pipeline
    /// </summary>
    /// <param name="app">The web host environment automatically passed in</param>
    /// <param name="env">The application builder automatically passed in</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataInitializor initializer)
    {
        if (!env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseExceptionHandler(Routes.Error);
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
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage(Routes.Fallback);
        });

        initializer.Initialize();
    }
}
