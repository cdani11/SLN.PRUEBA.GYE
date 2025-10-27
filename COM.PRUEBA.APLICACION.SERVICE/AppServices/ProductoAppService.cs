using System;
using COM.PRUEBA.APLICACION.DTOs.Producto;
using COM.PRUEBA.APLICACION.Interfaces.AppServices;
using COM.PRUEBA.DOMAIN.exception;
using COM.PRUEBA.DOMAIN.Utilities;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using COM.PRUEBA.QUERY.interfaces;

namespace COM.PRUEBA.APLICACION.SERVICE.AppServices;

public class ProductoAppService : IProductoAppServices
{
    protected readonly IProductoQueryService productoQueryService;

    public ProductoAppService(IProductoQueryService productoQueryService)
    {
        this.productoQueryService = productoQueryService;
    }

    public async Task<SharedAppResultDto<List<ProductoQueryDto>>> ConsultarProductosAsync()
    {
        var seccion = string.Empty;
        string mensaje = string.Empty;
        SharedAppResultDto<List<ProductoQueryDto>> resultApp = new();

        try
        {
            seccion = "Consulta de productos";
            var result = await productoQueryService.ConsultarProductosAsync();

            resultApp = new SharedAppResultDto<List<ProductoQueryDto>>
            {
                Result = result
            };
            
            return resultApp;
        }
        catch (PruebaValidacionesExeptions ex)
        {
            mensaje = $" {ex.pruebaValException?.Mensaje}";
            resultApp = new SharedAppResultDto<List<ProductoQueryDto>> { MensajeRespuesta = $"{mensaje}", Result = new List<ProductoQueryDto>() };
            return resultApp;
        }
        catch (PruebaException e)
        {
            mensaje = $"{e.Mensaje}";
            resultApp = new SharedAppResultDto<List<ProductoQueryDto>> { MensajeRespuesta = $"{mensaje}", Result = new List<ProductoQueryDto>() };
            return resultApp;

        }
        catch (Exception ex)
        {
            mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
            resultApp = new SharedAppResultDto<List<ProductoQueryDto>> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso" };
            return resultApp;
        }
    }

    public async Task<SharedAppResultDto<bool>> RegistrarProductoAsync(ProductoAppDto producto)
    {
        var seccion = string.Empty;
        string mensaje = string.Empty;
        SharedAppResultDto<bool> resultApp = new();

        try
        {
            seccion = "Registro de producto";
            var result = await productoQueryService.RegistrarProductoAsync(producto.Nombre, producto.Descripcion, producto.Categoria, producto.Imagen, producto.Precio, producto.Stock);

            resultApp = new SharedAppResultDto<bool>
            {
                Result = result
            };

            return resultApp;
        }
        catch (PruebaValidacionesExeptions ex)
        {
            mensaje = $" {ex.pruebaValException?.Mensaje}";
            resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
            return resultApp;
        }
        catch (PruebaException e)
        {
            mensaje = $"{e.Mensaje}";
            resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
            return resultApp;

        }
        catch (Exception ex)
        {
            mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
            resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso" };
            return resultApp;
        }
    }

    public Task<SharedAppResultDto<bool>> ActualizarProductoAsync(ProductoAppDto producto)
    {
        throw new NotImplementedException();
    }

    public Task<SharedAppResultDto<bool>> EliminarProductoAsync(long productoId)
    {
        throw new NotImplementedException();
    }
}
