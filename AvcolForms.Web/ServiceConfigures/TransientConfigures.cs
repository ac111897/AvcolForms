﻿using AvcolForms.Core.Email;
using AvcolForms.Core.FileSaving;
using AvcolForms.Core.Notifications;
using AvcolForms.Core.Options;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AvcolForms.Web.ServiceConfigures;

/// <summary>
/// Provides the static method to configure transient services in the <see cref="IServiceCollection"/>
/// </summary>
internal static class TransientConfigures
{
    /// <summary>
    /// Adds lifetime service of transient to the service collection for dependancy injection
    /// </summary>
    /// <param name="services">The service collection to configure</param>
    /// <param name="configuration">Configuration used to configure transient services</param>
    /// <returns>The same <see cref="IServiceCollection"/> used for chaining</returns>
    internal static IServiceCollection AddTransientServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFileSaver, FileSaver>();
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
