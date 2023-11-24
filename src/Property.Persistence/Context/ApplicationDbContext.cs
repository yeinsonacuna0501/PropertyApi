using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Property.Persistence.Context
{
    /// <summary>
    /// Clase que gestiona la creación de conexiones a la base de datos.
    /// </summary>
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        /// <summary>
        /// Constructor que inicializa la clase con la configuración de conexión proporcionada.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("PropertyConnection")!;
        }

        /// <summary>
        /// Método que crea y devuelve una nueva conexión a la base de datos.
        /// </summary>
        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
