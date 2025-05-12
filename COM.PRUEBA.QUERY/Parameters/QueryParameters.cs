using COM.PRUEBA.DOMAIN.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.Parameters
{
    public class QueryParameters
    {
        public static PRUEBATipoORM TipoORM { set; get; } = PRUEBATipoORM.EntityFramework;
        public static string ConnectionString { set; get; }
    }
}
