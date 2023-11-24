using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Property.Application.UseCase.Commons.Behaviours;
using System.Reflection;


namespace Property.Application.UseCase.Extensions
{
    /// <summary>
    /// Clase para la inyección de dependencias en la capa de casos de uso.
    /// </summary>
    public static class InjectionExtensions
    {
        /// <summary>
        /// Método para agregar servicios de aplicación.
        /// </summary>
        /// <param name="services">Colección de servicios de inyección de dependencias.</param>
        /// <returns>Colección de servicios con las configuraciones agregadas.</returns>
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {           
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;

        }    

    }
}
