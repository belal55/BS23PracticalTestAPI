using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class DependancyInjector
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IVote, VoteService>();

            return services;
        }
    }
}
