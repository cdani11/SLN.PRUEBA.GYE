using COM.PRUEBA.DOMAIN.Constans;

namespace PRUEBA.TRANSAC.API.Constants
{
    public static class ApiAdminConstants
    {
        static string prefijoController = "api/";

        public static string[] PathsServicioUsuario = new string[] {
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_CONSULTA,
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_REGISTROSOLICITUD,
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_ACTUALIZARSOLICITUD,
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_ELIMINARSOLICITUD,
        };

        public static string[] PathsServicioSupervisor = new string[] {
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_CONSULTA,
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_APROBACION,
            prefijoController+DomainConstants.PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_HISTORIALSOLICITUDES,
        };
        public static string[] GetServicesUsuario()
        {
            List<string> result = new List<string>();
            result.AddRange(PathsServicioUsuario);
            return result.ToArray();
        }
        public static string[] GetServicesSupervisor()
        {
            List<string> result = new List<string>();
            result.AddRange(PathsServicioSupervisor);
            return result.ToArray();
        }
    }
}
