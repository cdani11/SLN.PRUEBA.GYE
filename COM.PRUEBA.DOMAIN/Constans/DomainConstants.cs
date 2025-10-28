using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.Constans
{
    public class DomainConstants
    {
        public const long PRUEBA_DB_TIMEOUT = 120;
        public const string PRUEBA_CULTUREINFO = "es-EC";

        #region KEY ENCRIPTACION PRUEBA
        public const string PRUEBA_KEYENCRIPTA = "P@ssw0rd!Ex@mple";
        public const string PRUEBA_SALTO = "s@ltV@lu3Ex@mple!";
        #endregion

        #region NOMBRES DE MÉTODOS API AUTH
        public const string PRUEBA_METHODNAME_API_AUTH = "Login";
        #endregion

        #region NOMBRES DE MÉTODOS API PRODUCTOS
        public const string PRUEBA_METHODNAME_API_PRODUCTOS_CONSULTA = "ConsultarProductos";
        public const string PRUEBA_METHODNAME_API_PRODUCTOS_DETALLE = "ConsultarDetalleProducto";
        #endregion

        #region NOMBRES DE MÉTODOS API TRANSACCIONES
        public const string PRUEBA_METHODNAME_API_TRANSACCIONES_REGISTRO = "RegistrarTransaccion";
        #endregion
    }
}
