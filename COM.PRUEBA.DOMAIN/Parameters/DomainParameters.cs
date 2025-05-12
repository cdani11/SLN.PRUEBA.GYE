using COM.PRUEBA.DOMAIN.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.Parameters
{
    public class DomainParameters
    {
        public static PRUEBAAmbiente? APP_AMBIENTE { get; set; }
        public static string? APP_NOMBRE { get; set; }
        public static PRUEBAComponente APP_COMPONENTE { get; set; }


        public static string? PRUEBA_JWT_KEY { get; set; }
        public static string? PRUEBA_JWT_ISSUER { get; set; }
        public static double PRUEBA_JWT_EXPIRES { get; set; }
        public static decimal PRUEBA_MONTOMAXIMO_VALIDACION { get; set; }
        public static string PRUEBA_URL_PORTAL { get; set; }
    }
}
