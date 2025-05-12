using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.Parameters;
using COM.PRUEBA.QUERY.SERVICE.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE.Model
{
    public partial class PruebaQueryContext : PruebaQueryContextEF
    {
        internal async Task<LoginQueryDto> Login(string Usuario, string ClaveEncriptada)
        {
            string SP_NAME = "[sp_LoginUsuario]";
            LoginQueryDto? result = null;


            switch (QueryParameters.TipoORM)
            {
                case PRUEBATipoORM.EntityFramework:

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(Usuario);
                    sqlParameters.Add(ClaveEncriptada);
                    var results = pruebaQueryContextEF.ExecuteMultipleResults($"[{SP_NAME}] @p0,@p1", sqlParameters.ToArray(), typeof(LoginQueryDto));
                    result = results[0].Cast<LoginQueryDto>().ToList().FirstOrDefault();

                    break;
                case PRUEBATipoORM.Dapper:
                    using (var connection = pruebaQueryContextDP.CreateConnection())
                    {

                        (string, object)[] parametros = new (string, object)[]
                        {
                                    ("@NombreUsuario", Usuario),
                                    ("@Contrasena", ClaveEncriptada),
                        };
                        using (var reader = await connection.ExecuteMultipleResults(SP_NAME, parametros, typeof(LoginQueryDto)))
                        {
                            result = reader.Read<LoginQueryDto>().ToList().FirstOrDefault();
                        }
                    }
                    break;
            }
            return result;
        }
    }
}
