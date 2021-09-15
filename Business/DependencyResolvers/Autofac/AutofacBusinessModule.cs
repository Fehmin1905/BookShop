using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Interceptors;
using DataAccess.DataAccess.UnitOfWork;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<BookDal>().As<IBookDal>().InstancePerLifetimeScope();
            builder.RegisterType<BookCategoryDal>().As<IBookCategoryDal>().SingleInstance();
            builder.RegisterType<BookManager>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<BookCategoryManager>().As<IBookCategoryService>().SingleInstance();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
