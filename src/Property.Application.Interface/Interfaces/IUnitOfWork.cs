using Property.Domain.Entities;

namespace Property.Application.Interface.Interfaces
{
    /// <summary>
    /// Interfaz para el patrón Unit of Work.
    /// Administra instancias de varios repositorios para transacciones .
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repositorio genérico para la entidad Owner.
        /// </summary>
        IGenericRepository<Owner> Owner { get; }

        /// <summary>
        /// Repositorio específico para la entidad Property.
        /// </summary>
        IPropertyRepository Property { get; }

        /// <summary>
        /// Repositorio específico para la entidad User.
        /// </summary>
        IUserRepository User { get; }

    }
}
