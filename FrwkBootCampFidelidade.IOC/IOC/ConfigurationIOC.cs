using Autofac;
using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Aplicacao.Services;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using FrwkBootCampFidelidade.Dominio.WalletContext.Entities;
using FrwkBootCampFidelidade.DTO.BonificationContext;
using FrwkBootCampFidelidade.DTO.WalletContext;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Infraestrutura.IOC.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC Application
            builder.RegisterType<BonificationService>().As<IBonificationService>();
            builder.RegisterType<WalletService>().As<IWalletService>();
            #endregion

            #region IOC Mapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                #region Bonification
                cfg.CreateMap<Bonification, BonificationDTO>();
                cfg.CreateMap<BonificationDTO, Bonification>();
                cfg.CreateMap<List<BonificationDTO>, List<Bonification>>();
                cfg.CreateMap<List<Bonification>, List<BonificationDTO>>();

                cfg.CreateMap<Wallet, WalletDTO>();
                cfg.CreateMap<WalletDTO, Wallet>();
                cfg.CreateMap<List<WalletDTO>, List<Wallet>>();
                cfg.CreateMap<List<Wallet>, List<WalletDTO>>();
                #endregion

            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion
        }
    }
}
