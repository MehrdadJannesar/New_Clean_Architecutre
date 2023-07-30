using CA.Application.CommonModels;
using CA.Application.Contracts.Infrastructure;
using CA.Infrastructrue.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Infrastructrue
{
    public static class InfrastructreServicesRegistration
    {
        public static IServiceCollection ConfigurationServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
