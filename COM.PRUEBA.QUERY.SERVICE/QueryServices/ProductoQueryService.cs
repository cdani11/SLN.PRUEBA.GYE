using System;
using COM.PRUEBA.DOMAIN.exception;
using COM.PRUEBA.DOMAIN.exception.DTOs;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.interfaces;
using COM.PRUEBA.QUERY.SERVICE.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace COM.PRUEBA.QUERY.SERVICE.QueryServices;

public class ProductoQueryService : BaseQueryService, IProductoQueryService
{
    public ProductoQueryService(IServiceScopeFactory serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<List<ProductoQueryDto>?> ConsultarProductosAsync()
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

            try
            {
                return await pruebaQueryContext.ConsultarProductosAsync();
            }
            catch (SqlException ex) when (ex.Number == 50001)
            {
                throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el listado de productos.", ex);
            }
        }
    }

    public async Task<bool> RegistrarProductoAsync(string nombre, string descripcion, short categoria, byte[]? imagen, decimal precio, int stock)
    {
        try
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                try
                {
                    return await pruebaQueryContext.InsertarProductoAsync(nombre, descripcion, categoria, imagen, precio, stock);
                }
                catch (SqlException ex) when (ex.Number == 50001)
                {
                    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ingresar un producto.", ex);
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Task<bool> ActualizarProductoAsync(int id, string nombre, string descripcion, short categoria, byte[]? imagen, decimal precio, int stock)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EliminarProductoAsync(int id)
    {
        throw new NotImplementedException();
    }
}
