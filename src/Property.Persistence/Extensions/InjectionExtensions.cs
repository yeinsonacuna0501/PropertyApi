using Microsoft.Extensions.DependencyInjection;
using Property.Application.Interface;
using Property.Application.Interface.Interfaces;
using Property.Persistence.Context;
using Property.Persistence.Repositories;

namespace Property.Persistence.Extensions
{
    /// <summary>
    /// Clase  que define métodos para la configuración de inyección de dependencias relacionadas con la persistencia.
    /// </summary>
    public static class InjectionExtensions
    {
        /// <summary>
        /// Método para agregar servicios relacionados con la persistencia al contenedor de servicios.
        /// </summary>
        /// <param name="services">Colección de servicios a la que se agregan los servicios de persistencia.</param>
        /// <returns>La colección de servicios actualizada con los servicios de persistencia agregados.</returns>
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>(); // Registro de ApplicationDbContext como Singleton
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // Registro de IGenericRepository<> y GenericRepository<> como Scoped
            services.AddTransient<IUnitOfWork, UnitOfWork>(); // Registro de IUnitOfWork como Transient
            return services; // Devuelve la colección de servicios actualizada
        } 
    }
}
