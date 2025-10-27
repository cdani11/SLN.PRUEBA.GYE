using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace COM.PRUEBA.QUERY.SERVICE.Model;

public partial class PruebaQueryContext : PruebaQueryContextEF
{
    internal async Task<bool> InsertarProductoAsync(string nombre, string descripcion, short categoria, byte[]? imagen, decimal precio, int stock)
    {
        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = nombre },
            new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = descripcion },
            new SqlParameter("@Categoria", SqlDbType.SmallInt) { Value = categoria },
            new SqlParameter("@Imagen", SqlDbType.VarBinary) { Value = imagen ?? (object)DBNull.Value },
            new SqlParameter("@Precio", SqlDbType.Decimal) { Value = precio },
            new SqlParameter("@Stock", SqlDbType.Int) { Value = stock },
        };

        var command = $"[INS_Producto] {string.Join(", ", parameters.Select(p => p.ParameterName))}";
        var result = await Database.ExecuteSqlRawAsync(command, parameters.ToArray());
        return result != 0;
    }
}
