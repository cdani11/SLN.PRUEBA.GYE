using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyHelpers.Extensions;

namespace PRUEBA.COMMON.PRESENTACION.Utilities
{
    public static class CommonUtilities
    {
        public static bool NextMiddleware(string[] services, string service)
        {
            if (service == "index" || service == "swagger")
                return true;
            if (!services.Any(x => x.EqualsIgnoreCase(service)))
                return true;
            return false;
        }

    }
}
