using donations.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesExtended
    {
        public static IServiceCollection AddDonationsServices(this IServiceCollection services)
        {
            services.AddSingleton<IDonationsService, DonationsService>();

            return services;
        }
    }
}