using Microsoft.Extensions.DependencyInjection;
using SMTP.Services;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class SMTPxtended
    {
        public static IServiceCollection AddMailServices(this IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}