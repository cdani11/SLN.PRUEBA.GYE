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
    public class UsuarioController : ControllerBase
    {
        private readonly IAdminAppServices adminAppServices;
        public UsuarioController(IAdminAppServices adminAppServices)
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<List<SolicitudQueryDto>>))]
        [HttpGet(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_CONSULTA)]
        [ServiceFilter(typeof(ValidateModelConsultaSolicitudes))]
        public async Task<IActionResult> consultaAsync(string Usuario)
        {
            try
            {
                var result = await adminAppServices.ConsultarSolicitudesPorUsuario(Usuario);

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
        /// Registrar solicitudes por el usuario
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpPost(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_REGISTROSOLICITUD)]
        [ServiceFilter(typeof(ValidateModelRegistroSolicitudesXUsuario))]
        public async Task<IActionResult> registroAsync(RegistroSolicitudAppDto Solicitud)
        {
            try
            {
                var result = await adminAppServices.RegistrarSolicitud(Solicitud);

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
        /// Registrar solicitudes por el usuario
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpPut(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_ACTUALIZARSOLICITUD)]
        [ServiceFilter(typeof(ValidateModelRegistroSolicitudesXUsuario))]
        public async Task<IActionResult> ActualizarregistroAsync(ActualizarSolicitudAppDto Solicitud)
        {
            try
            {
                var result = await adminAppServices.ActualizarSolicitud(Solicitud);

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
        /// Registrar solicitudes por el usuario
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpDelete(DomainConstants.PRUEBA_METHODNAME_API_ADMIN_ELIMINARSOLICITUD)]
        [ServiceFilter(typeof(ValidateModelEliminarSolicitud))]
        public async Task<IActionResult> EliminarSolicitud(long idSolicitud, string Usuario)
        {
            try
            {
                var result = await adminAppServices.EliminarSolicitud(idSolicitud, Usuario);

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
