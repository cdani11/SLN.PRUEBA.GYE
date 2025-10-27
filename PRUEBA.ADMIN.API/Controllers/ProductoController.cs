using COM.PRUEBA.APLICACION.DTOs.Producto;
using COM.PRUEBA.APLICACION.Interfaces.AppServices;
using COM.PRUEBA.APLICACION.SERVICE.Constants;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PRUEBA.ADMIN.API.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoAppServices productoAppServices;
        public ProductoController(IProductoAppServices productoAppServices)
        {
            this.productoAppServices = productoAppServices;
        }

        /// <summary>
        /// Consultar productos
        /// </summary>
        /// <returns>Tipo List<ProductoQueryDto></returns>
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<List<ProductoQueryDto>>))]
        [HttpGet]
        public async Task<IActionResult> ConsultarAsync()
        {
            try
            {
                var result = await productoAppServices.ConsultarProductosAsync();

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
        /// Registrar producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Tipo booleano</returns>
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpPost]
        public async Task<IActionResult> RegistrarAsync(ProductoAppDto producto)
        {
            try
            {
                var result = await productoAppServices.RegistrarProductoAsync(producto);

                return Ok(true);
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
        /// Actualizar producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Tipo booleano</returns>
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        /// [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpPut]
        public async Task<IActionResult> ActualizarAsync(ProductoAppDto producto)
        {
            try
            {
                var result = await productoAppServices.ActualizarProductoAsync(producto);

                return Ok(true);
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
        /// Eliminar producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns>Tipo booleano</returns>
        /// <response code="200">OK. Procesado correctamente.</response>
        /// <response code="500">Error. Verificar mensaje de excepción</response>
        /// <response code="401">Credenciales inválidas</response>
        /// [Consumes(AppConstants.WEB_API_TYPE_JSON)]
        [Produces(AppConstants.WEB_API_TYPE_JSON)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SharedAppResultDto<bool>))]
        [HttpDelete]
        public async Task<IActionResult> EliminarAsync(int productoId)
        {
            try
            {
                var result = await productoAppServices.EliminarProductoAsync(productoId);

                return Ok(true);
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
