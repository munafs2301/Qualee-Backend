using MediatR;
using FluentValidation;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using QualeeBackend.Application.Behaviours;

namespace QualeeBackend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            //services.AddAutoMapper(assembly);
            //services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
