using Property.Application.Interface.Interfaces;
using Property.Domain.Entities;
using Property.Persistence.Context;

namespace Property.Persistence.Repositories
{
    /// <summary>
    /// Clase que implementa UnitOfWork para manejar múltiples repositorios.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Repositorio genérico para la entidad Owner.
        /// </summary>
        public IGenericRepository<Owner> Owner { get; }

        /// <summary>
        /// Repositorio específico para la entidad Property.
        /// </summary>
        public IPropertyRepository Property { get; }

        /// <summary>
        /// Repositorio específico para la entidad User.
        /// </summary>
        public IUserRepository User { get; }

        /// <summary>
        /// Constructor que inicializa UnitOfWork con instancias de repositorios.
        /// </summary>
        /// <param name="owner">Repositorio genérico para la entidad Owner.</param>
        /// <param name="context">Instancia de ApplicationDbContext.</param>
        public UnitOfWork(IGenericRepository<Owner> owner, ApplicationDbContext context)
        {
            _context = context;
            Owner = owner;
            Property = new PropertyRepository(_context);
            User = new UserRepository(_context);

        }

        /// <summary>
        /// Libera los recursos no administrados utilizados por UnitOfWork.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
