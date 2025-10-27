using System;
using COM.PRUEBA.APLICACION.DTOs.Producto;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;

namespace COM.PRUEBA.APLICACION.Interfaces.AppServices;

public interface IProductoAppServices
{
    Task<SharedAppResultDto<List<ProductoQueryDto>>> ConsultarProductosAsync();
    Task<SharedAppResultDto<bool>> RegistrarProductoAsync(ProductoAppDto producto);
    Task<SharedAppResultDto<bool>> ActualizarProductoAsync(ProductoAppDto producto);
    Task<SharedAppResultDto<bool>> EliminarProductoAsync(long productoId);
}
