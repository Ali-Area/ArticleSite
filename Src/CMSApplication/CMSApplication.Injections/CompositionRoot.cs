using Autofac;
using Autofac.Extras.DynamicProxy;
using CMSApplication.Application.Contracts.Admin;
using CMSApplication.Application.Contracts.Site;
using CMSApplication.Application.Services.Admin;
using CMSApplication.Application.Services.Site;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.Persistance;
using CMSApplication.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMSApplication.Injections
{
    public static class CompositionRoot
    {
        public static ContainerBuilder RegisterContainerDependency(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                   .As<IUnitOfWork>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWorkInterceptor>()
                   .AsSelf()
                   .InstancePerLifetimeScope();


            builder.RegisterType<UsersService>()
                   .As<IUsersService>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(UnitOfWorkInterceptor))
                   .InstancePerDependency();

            builder.RegisterType<CategoryService>()
                   .As<ICategoryService>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(UnitOfWorkInterceptor))
                   .InstancePerDependency();

            builder.RegisterType<FrontUserService>()
                    .As<IFrontUserService>()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(UnitOfWorkInterceptor))
                    .InstancePerDependency();

            builder.RegisterType<FrontCategoryService>()
                   .As<IFrontCategoryService>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(UnitOfWorkInterceptor))
                   .InstancePerDependency();

            builder.RegisterType<FrontArticleService>()
                    .As<IFrontArticleService>()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(UnitOfWorkInterceptor))
                    .InstancePerDependency();


            builder.RegisterType<ArticleService>()
                    .As<IArticleService>()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(UnitOfWorkInterceptor))
                    .InstancePerDependency();

            return builder;
        }
    }
}
