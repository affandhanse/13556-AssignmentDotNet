using EcommerceApp.Application.Interface;
using EcommerceApp.Infrastructure.Context;
using EcommerceApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EcommerceApp.Infrastructure
{
    public static class InterfaceServiceRegistration
    {

        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //return services;
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EcommerceString"));


            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            return services;

        }
    }
}
