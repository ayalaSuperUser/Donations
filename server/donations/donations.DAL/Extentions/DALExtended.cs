using donations.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class DALExtended
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            services.AddSingleton<IDonationsContext, DonationsContext>();

            return services;
        }
    }
}