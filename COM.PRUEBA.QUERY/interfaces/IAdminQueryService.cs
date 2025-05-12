using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.interfaces
{
    public interface IAdminQueryService
    {
        Task<List<SolicitudQueryDto>> ConsultarSolicitudesPorUsuario(string Usuario);
        Task<bool> RegistrarSolicitud(string descripcion, DateTime fechaSolicitud, int tipoCompra, int estado, string direccionSolicitante, string nombre, string usuario);
        Task<bool> ActualizarSolicitud(long IdSolicitud, string descripcion, DateTime fechaSolicitud, int tipoCompra, int estado, string direccionSolicitante, string nombre, string usuario);
        Task<bool> EliminarSolicitud(long IdSolicitud, string usuario);
        Task<List<SolicitudPorEstadoQueryDto>> ConsultarSolicitudesPorEstado(int Estado);
        Task<List<SolicitudQueryDto>> ConsultarSolicitudPorId(int idSolicitud);
    }
}
