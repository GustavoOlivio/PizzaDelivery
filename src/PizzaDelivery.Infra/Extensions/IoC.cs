using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.Repository.Repositories;
using PizzaDelivery.Services.Services;

namespace PizzaDelivery.Infra.Extensions
{
    public static class IoC
    {
        public static IServiceCollection RegistrarServicosPorNome(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(BaseService), typeof(MasterRepository))
                    .AddClasses(c => c.Where(n => n.Name.EndsWith("Service")))
                        .AsImplementedInterfaces()
                    .AddClasses(c => c.Where(n => n.Name.EndsWith("Repository")))
                        .AsImplementedInterfaces());

            return services;
        }
    }
}