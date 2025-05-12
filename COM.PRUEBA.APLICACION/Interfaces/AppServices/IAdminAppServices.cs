using COM.PRUEBA.APLICACION.DTOs.Admin;
using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.APLICACION.Interfaces.AppServices
{
    public interface IAdminAppServices
    {
        Task<SharedAppResultDto<List<SolicitudQueryDto>>> ConsultarSolicitudesPorUsuario(string Usuario);
        Task<SharedAppResultDto<bool>> RegistrarSolicitud(RegistroSolicitudAppDto Solicitud);
        Task<SharedAppResultDto<bool>> ActualizarSolicitud(ActualizarSolicitudAppDto Solicitud);
        Task<SharedAppResultDto<bool>> EliminarSolicitud(long id, string Usuario);
        Task<SharedAppResultDto<bool>> AprobarSolicitud(AprobarSolicitud Solicitud);
        Task<SharedAppResultDto<List<SolicitudPorEstadoQueryDto>>> ConsultarSolicitudesPorEstado(int Estado);
    }
}
