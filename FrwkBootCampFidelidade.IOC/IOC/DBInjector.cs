using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Aplicacao.Services.RpcService;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.OrderContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.ProductContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.WalletContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Data.ProductContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Data.WalletContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.RansomContext.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FrwkBootCampFidelidade.Infraestrutura.IOC.IOC
{
    public static class DBInjector
    {
        public static void AddDBInjector(this IServiceCollection services)
        {
            services.AddScoped<IRpcClientService, RpcClientService>();

            services.AddScoped<IBonificationRepository, BonificationRepository>();
            services.AddScoped<IRansomRepository, RansomRepository>();
            services.AddScoped<IRansomHistoryStatusRepository, RansomHistoryStatusRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletTypeRepository, WalletTypeRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWalletHistoryTransferRepository, WalletHistoryTransferRepository>();
        }
    }
}
