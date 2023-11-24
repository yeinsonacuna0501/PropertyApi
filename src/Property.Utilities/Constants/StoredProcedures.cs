using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Utilities.Constants
{
    /// <summary>
    /// Clase que contiene nombres de procedimientos almacenados (stored procedures) utilizados en la aplicación.
    /// </summary>
    public class SP
    {
        #region spOwner
        public const string spOwnerList = "spOwnerList";
        public const string spOwnerById = "spOwnerById";
        public const string spOwnerRegister = "spOwnerRegister";
        public const string spOwnerEdit = "spOwnerEdit";
        #endregion spOwner

        #region spProperty
        public const string spPropertyRegister = "spPropertyRegister";
        public const string spPropertyEdit = "spPropertyEdit";
        public const string spPropertyChangePrice = "spPropertyChangePrice";
        public const string spPropertyListFilter = "spPropertyListFilter";
        public const string spPropertyAddImage = "spPropertyAddImage";
        public const string spImagesProperty = "spImagesProperty";
        public const string spTracesProperty = "spTracesProperty";
        #endregion spProperty

        #region spUser
        public const string spLogin = "spLogin";
        #endregion spUser

    }
}
