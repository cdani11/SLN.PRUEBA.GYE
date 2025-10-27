using System;

namespace COM.PRUEBA.QUERY.DTOs;

public class ProductoQueryDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public short Categoria { get; set; }
    public byte[]? Imagen { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

}
