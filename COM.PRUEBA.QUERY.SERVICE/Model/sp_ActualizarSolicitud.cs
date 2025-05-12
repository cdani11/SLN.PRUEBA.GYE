using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace COM.PRUEBA.QUERY.SERVICE.Model
{
    public partial class PruebaQueryContext : PruebaQueryContextEF
    {
        internal async Task<bool> ActualizarSolicitud(long IdSolicitud, string descripcion, DateTime fechaSolicitud, int tipoCompra, int estado, string direccionSolicitante, string nombre, string usuario)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdSolicitud", SqlDbType.Int) { Value = IdSolicitud },
                    new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = descripcion },
                    new SqlParameter("@UsuarioCreacion", SqlDbType.VarChar) { Value = usuario },
                    new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = nombre },
                    new SqlParameter("@DireccionSolicitante", SqlDbType.VarChar) { Value = direccionSolicitante },
                    new SqlParameter("@EstadoSolicitud", SqlDbType.Int) { Value = estado },
                    new SqlParameter("@TipoCompra", SqlDbType.Int) { Value = tipoCompra },
                    new SqlParameter("@FechaSolicitud", SqlDbType.DateTime) { Value = fechaSolicitud },
                };

            var command = $"[sp_ActualizarSolicitud] {string.Join(", ", parameters.Select(p => p.ParameterName))}";
            var result = await Database.ExecuteSqlRawAsync(command, parameters.ToArray());
            return result != 0;
        }

    }
}
