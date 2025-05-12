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


        public const string PRUEBA_METHODNAME_API_AUTH = "Login";
        public const string PRUEBA_METHODNAME_API_ADMIN_CONSULTA = "ConsultarSolicitudesPorUsuario";
        public const string PRUEBA_METHODNAME_API_ADMIN_REGISTROSOLICITUD = "RegistrarSolicitudPorUsuario";
        public const string PRUEBA_METHODNAME_API_ADMIN_ACTUALIZARSOLICITUD = "ActualizarSolicitudPorUsuario";
        public const string PRUEBA_METHODNAME_API_ADMIN_ELIMINARSOLICITUD = "EliminarSolicitudPorUsuario";


        public const string PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_CONSULTA = "ConsultarSolicitudesPendientes";
        public const string PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_APROBACION = "AprobarSolicitud";
        public const string PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_HISTORIALSOLICITUDES = "HistorialSolicitudesAprobadas";

    }
}
