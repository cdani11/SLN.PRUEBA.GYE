using COM.PRUEBA.APLICACION.Interfaces.AppServices;
using COM.PRUEBA.APLICACION.SERVICE.AppServices;
using COM.PRUEBA.APLICACION.SERVICE.Constants;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.QUERY.DTOs.Shared;
using COM.PRUEBA.QUERY.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRUEBA.ADMIN.API.Filter;
using COM.PRUEBA.APLICACION.DTOs.Admin;

namespace PRUEBA.ADMIN.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class SupervisorController : ControllerBase
    {
        private readonly IAdminAppServices adminAppServices;
        public SupervisorController(IAdminAppServices adminAppServices)
        {
            this.adminAppServices = adminAppServices; ;
        }


        /// <summary>
        /// Consultar solicitudes ingresadas por el usuario
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<List<SolicitudPorEstadoQueryDto>>))]
        [HttpGet(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_CONSULTA)]
        public async Task<IActionResult> consultaSolicitudesPendientesAsync()
        {
            try
            {
                var result = await adminAppServices.ConsultarSolicitudesPorEstado((int)EstadoSolicitudes.Pendiente);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }


        /// <summary>
        /// Metodo para aprobar o rechazar las solicitudes
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpPut(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_APROBACION)]
        [ServiceFilter(typeof(ValidateModelAprobarSolicitud))]
        public async Task<IActionResult> AprobacionSolicitudAsync(AprobarSolicitud Aprobacion)
        {
            try
            {
                var result = await adminAppServices.AprobarSolicitud(Aprobacion);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }


        /// <summary>
        /// se consulta todas las solicitudes Aprobadas
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<List<SolicitudPorEstadoQueryDto>>))]
        [HttpGet(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_SUPERVISOR_HISTORIALSOLICITUDES)]
        public async Task<IActionResult> HistorialSolicitudesAprobadasAsync()
        {
            try
            {
                var result = await adminAppServices.ConsultarSolicitudesPorEstado((int)EstadoSolicitudes.Aprobada);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
    }
}
