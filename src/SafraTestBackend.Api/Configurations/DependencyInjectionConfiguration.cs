using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Notifications;
using SafraTestBackend.Business.Services;
using SafraTestBackend.Business.Services.ApiQuotation;
using SafraTestBackend.Data;
using SafraTestBackend.Data.Repository;
using SafraTestBackend.Domain.Repository;

namespace SafraTestBackend.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IStocksRepository, StocksRepository>();

            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IStocksService, StocksService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IQuotationService, QuotationService>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TestDbConnection")));

            return services;
        }
    }
}
