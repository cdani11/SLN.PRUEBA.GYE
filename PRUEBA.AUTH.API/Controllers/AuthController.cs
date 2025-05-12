using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.APLICACION.Interfaces.AppServices;
using COM.PRUEBA.APLICACION.SERVICE.Constants;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRUEBA.AUTH.API.ApiExtensions;
using PRUEBA.AUTH.API.Filter;

namespace PRUEBA.AUTH.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : Controller
    {

        private readonly ILoginAppServices loginAppService;
        public AuthController(ILoginAppServices loginAppService)
        {
            this.loginAppService = loginAppService; ;
        }
        /// <summary>
        /// Realizar login
        /// </summary>      
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<LoginQueryDto>))]
        [HttpPost(DomainConstants.PRUEBA_METHODNAME_API_AUTH)]
        [ServiceFilter(typeof(ValidateModelAuthPrueba))]
        public async Task<IActionResult> Login([FromBody] CredencialesLoginAppDto credencialesLogin)
        {
            try
            {
                var result = await loginAppService.Login(credencialesLogin, HttpContext.Request.GetOnlyUrl());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            finally
            {
            }
        }
    }
}
