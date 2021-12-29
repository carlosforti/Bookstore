using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;

using Bookstore.Application.Interfaces;
using Bookstore.Infra.Data.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.Data.Configuration
{
    public static class InfraDataConfiguration
    {
        public static IServiceCollection ConfigureInfraDataServices(this IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
