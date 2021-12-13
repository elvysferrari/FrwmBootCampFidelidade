using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.OrderContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.RansomContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Repository;
using Microsoft.Extensions.DependencyInjection;
using FrwkBootCampFidelidade.Dominio.WalletContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Data.WalletContext.Repository;

namespace FrwkBootCampFidelidade.Infraestrutura.IOC.IOC
{
    public static class DBInjector
    {
        public static void AddDBInjector(this IServiceCollection services)
        {
            services.AddScoped<IBonificationRepository, BonificationRepository>();
            services.AddScoped<IRansomRepository, RansomRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletTypeRepository, WalletTypeRepository>();
        }
    }
}
