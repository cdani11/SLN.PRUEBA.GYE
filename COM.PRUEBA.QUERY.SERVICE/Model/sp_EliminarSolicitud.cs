using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        internal async Task<bool> EliminarSolicitud(long IdSolicitud,  string usuario)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdSolicitud", SqlDbType.Int) { Value = IdSolicitud },
                    new SqlParameter("@UsuarioEliminacion", SqlDbType.VarChar) { Value = usuario },
                };

            var command = $"[sp_EliminarSolicitud] {string.Join(", ", parameters.Select(p => p.ParameterName))}";
            var result = await Database.ExecuteSqlRawAsync(command, parameters.ToArray());
            return result != 0;
        }
    }
}
