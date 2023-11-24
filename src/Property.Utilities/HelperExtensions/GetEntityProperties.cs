using System.Reflection;

namespace Property.Utilities.HelperExtensions
{
    /// <summary>
    /// Clase estática que contiene un método para obtener las propiedades y sus valores de un objeto.
    /// </summary>
    public static class GetEntityProperties
    {
        /// <summary>
        /// Método que obtiene las propiedades y sus valores de un objeto.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto.</typeparam>
        /// <param name="entity">Instancia del objeto.</param>
        /// <returns>Un diccionario con los nombres de las propiedades y sus respectivos valores no nulos.</returns>
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T entity)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var entityParams = new Dictionary<string, object>();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(entity, null)!;
                if(value != null)
                {
                    entityParams[property.Name] = value;
                }
            }
            return entityParams;

        }
    }
}
