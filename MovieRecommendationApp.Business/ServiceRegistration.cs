﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieRecommendationApp.DataAccess.Services;

namespace MovieRecommendationApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IFileService, IFileService>();

            serviceCollection.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
