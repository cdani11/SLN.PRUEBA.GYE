using System;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.Parameters;
using COM.PRUEBA.QUERY.SERVICE.Extensions;

namespace COM.PRUEBA.QUERY.SERVICE.Model;

public partial class PruebaQueryContext : PruebaQueryContextEF
{
    internal async Task<List<ProductoQueryDto>?> ConsultarProductosAsync()
    {
        string SP_NAME = "[QRY_Producto]";
        List<ProductoQueryDto>? result = null;

        switch (QueryParameters.TipoORM)
        {
            case PRUEBATipoORM.EntityFramework:
                var results = pruebaQueryContextEF.ExecuteMultipleResults($"[{SP_NAME}] @p0", null, typeof(List<ProductoQueryDto>));
                result = results[0].Cast<ProductoQueryDto>().ToList();

                break;
            case PRUEBATipoORM.Dapper:
                using (var connection = pruebaQueryContextDP.CreateConnection())
                {
                    using (var reader = await connection.ExecuteMultipleResults(SP_NAME, null, typeof(List<ProductoQueryDto>)))
                    {
                        result = reader.Read<ProductoQueryDto>().ToList();
                    }
                }
                break;
        }
        
        return result;
    }
}
