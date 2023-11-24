using XSystem.Security.Cryptography;

namespace Property.Utilities.HelperExtensions
{
    /// <summary>
    /// Clase que proporciona métodos para encriptar contraseñas utilizando el algoritmo MD5.
    /// </summary>
    public class GetPasswordMD5
    {
        /// <summary>
        /// Método estático para encriptar una cadena utilizando el algoritmo MD5.
        /// </summary>
        /// <param name="valor">La cadena a encriptar.</param>
        /// <returns>La cadena encriptada en formato hexadecimal.</returns>
        public static string obtenermd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
