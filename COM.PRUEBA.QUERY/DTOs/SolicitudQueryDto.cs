using COM.PRUEBA.DOMAIN.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.DTOs
{
    public class SolicitudQueryDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public EstadoSolicitudes EstadoSolicitud { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string DireccionSolicitante { get; set; } = string.Empty;
        public TipoCompra TipoCompra { get; set; }
        public DateTime FechaEsperada { get; set; }
    }
}
