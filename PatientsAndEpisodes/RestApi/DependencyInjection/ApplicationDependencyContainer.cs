using System.Reflection;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.WebApi;
using RestApi.Interfaces;
using RestApi.Models;
using System.Web.Configuration;

namespace RestApi.DependencyInjection
{
    public class ApplicationDependencyContainer
    {
        private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();

        private IContainer _container;

        public ApplicationDependencyContainer(Assembly apiAssembly)
        {
            _autofacContainerBuilder.RegisterApiControllers(apiAssembly);
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            //_autofacContainerBuilder.RegisterType<PatientContext>().As<IDatabaseContext>();
            //_autofacContainerBuilder.RegisterType<InMemoryPatientContext>().As<IDatabaseContext>();

            //_autofacContainerBuilder.RegisterType<PatientContext>().As<IDatabaseContext<PatientContext>>();
            //_autofacContainerBuilder.RegisterType<InMemoryPatientContext>().As<IDatabaseContext<InMemoryPatientContext>>();

            _autofacContainerBuilder.Register<IDatabaseContext>(c =>
                {

                    bool inMemoryContext = bool.Parse(WebConfigurationManager.AppSettings["GetInmemoryContext"].ToString());
                    if (inMemoryContext)
                    {
                        return new InMemoryPatientContext();
                    }
                    else
                    {
                        return new PatientContext();
                    }
                })

            .As<IDatabaseContext>()
            .SingleInstance();

        }

        public IDependencyResolver WebApiDependencyResolver
        {
            get { return new AutofacWebApiDependencyResolver(_container); }
        }

        public void OverrideRegistration<TInterface, TClass>() where TInterface : class where TClass : class, TInterface
        {
            _autofacContainerBuilder.RegisterType<TClass>().As<TInterface>().InstancePerLifetimeScope();
        }

        public void Build()
        {
            _container = _autofacContainerBuilder.Build();
        }

        public ILifetimeScope BeginLifetimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}