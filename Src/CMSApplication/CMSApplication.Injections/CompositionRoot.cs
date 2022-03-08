using Autofac;
using CMSApplication.Persistance;
using CMSApplication.Persistance.Context;
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

            


            return builder;
        }
    }
}
