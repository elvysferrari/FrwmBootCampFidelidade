﻿using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.Dominio.OrderContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.RansomContext.Repository;
using FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FrwkBootCampFidelidade.Infraestrutura.IOC.IOC
{
    public static class DBInjector
    {
        public static void AddDBInjector(this IServiceCollection services)
        {
            services.AddScoped<IBonification, BonificationRepository>();
            services.AddScoped<IRansom, RansomRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            services.AddScoped<IOrderItem, OrderItemRepository>();
        }
    }
}