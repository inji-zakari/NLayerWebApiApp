using Autofac;
using NLayerWebApi.Core.IRepositories;
using NLayerWebApi.Core.IServices;
using NLayerWebApi.Core.IUnitOfWork;
using NLayerWebApi.Repository;
using NLayerWebApi.Repository.Repositories;
using NLayerWebApi.Repository.UnitOfWorks;
using NLayerWebApi.Service.Mapping;
using NLayerWebApi.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayerWebApi.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
