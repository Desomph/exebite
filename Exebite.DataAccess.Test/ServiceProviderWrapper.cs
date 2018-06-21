﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Exebite.DataAccess;
using Exebite.DataAccess.Context;
using Exebite.DataAccess.Repositories;
using Exebite.DataAccess.Test.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace Exebite.DataAccess.Test
{
    public static class ServiceProviderWrapper
    {
        public static IServiceProvider GetContainer()
        {
            ServiceCollectionExtensions.UseStaticRegistration = false;
            var serviceProvider = new ServiceCollection()
                                        .AddLogging()
                                        .AddTransient<IFoodOrderingContextFactory, InMemoryDBFactory>()
                                        .AddTransient<IRestaurantRepository, RestaurantRepository>()
                                        .AddTransient<IFoodRepository, FoodRepository>()
                                        .AddTransient<IRecipeRepository, RecipeRepository>()
                                        .AddTransient<ICustomerRepository, CustomerRepository>()
                                        .AddTransient<ILocationRepository, LocationRepository>()
                                        .AddTransient<IOrderRepository, OrderRepository>()
                                        .AddTransient<IExebiteDbContextOptionsFactory, ExebiteDbContextOptionsFactory>()
                                        .AddAutoMapper(cfg =>
                                                    cfg.AddProfile<DataAccessMappingProfile>())
                                        ;


            //foreach (var item in outerCollection)
            //{
            //    serviceProvider.AddTransient(item.ImplementationInstance, item.Value);
            //}

            return serviceProvider.BuildServiceProvider();
        }

        public static T Resolve<T>(this IServiceProvider provider)
        {
            var res = (T)provider.GetService(typeof(T));
            return res;
        }
    }
}
