using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Project.Application.Services.CrewService;
using Project.Application.Services.CustomerService;
using Project.Application.Services.DeliveryService;
using Project.Application.Services.FoodInfoService;
using Project.Application.Services.OrderDetailService;

namespace Project.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<ICrewService, CrewManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IFoodInfoService, FoodInfoManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IDeliveryService, DeliveryManager>();

            return services;
        }

        private static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }

            return services;
        }
    }

}
