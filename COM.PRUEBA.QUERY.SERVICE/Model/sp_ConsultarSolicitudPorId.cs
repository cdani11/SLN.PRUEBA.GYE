using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.Parameters;
using COM.PRUEBA.QUERY.SERVICE.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE.Model
{
    public partial class PruebaQueryContext : PruebaQueryContextEF
    {
        internal async Task<List<SolicitudQueryDto>> ConsultarSolicitudPorId(int idSolicitud)
        {
            string SP_NAME = "[sp_ConsultarSolicitudPorId]";
            List<SolicitudQueryDto>? result = null;


            switch (QueryParameters.TipoORM)
            {
                case PRUEBATipoORM.EntityFramework:

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(idSolicitud);
                    var results = pruebaQueryContextEF.ExecuteMultipleResults($"[{SP_NAME}] @p0", sqlParameters.ToArray(), typeof(List<SolicitudQueryDto>));
                    result = results[0].Cast<SolicitudQueryDto>().ToList();

                    break;
                case PRUEBATipoORM.Dapper:
                    using (var connection = pruebaQueryContextDP.CreateConnection())
                    {

                        (string, object)[] parametros = new (string, object)[]
                        {
                                    ("@Id", idSolicitud),
                        };
                        using (var reader = await connection.ExecuteMultipleResults(SP_NAME, parametros, typeof(List<SolicitudQueryDto>)))
                        {
                            result = reader.Read<SolicitudQueryDto>().ToList();
                        }
                    }
                    break;
            }
            return result;
        }
    }
}
