using System;
using COM.PRUEBA.QUERY.DTOs;

namespace COM.PRUEBA.QUERY.interfaces;

public interface IProductoQueryService
{
    public Task<List<ProductoQueryDto>> ConsultarProductosAsync();
    public Task<bool> RegistrarProductoAsync(string nombre, string descripcion, short categoria, byte[]? imagen, decimal precio, int stock);
    public Task<bool> ActualizarProductoAsync(int id, string nombre, string descripcion, short categoria, byte[]? imagen, decimal precio, int stock);
    public Task<bool> EliminarProductoAsync(int id);
}
