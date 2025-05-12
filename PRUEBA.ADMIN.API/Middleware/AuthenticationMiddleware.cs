using Azure.Core;
using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.DOMAIN.exception;
using COM.PRUEBA.DOMAIN.Extensions;
using COM.PRUEBA.DOMAIN.Tools;
using COM.PRUEBA.DOMAIN.Utilities;
using PRUEBA.ADMIN.API.Constants;
using PRUEBA.COMMON.PRESENTACION.Extensions;
using PRUEBA.COMMON.PRESENTACION.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text.Json;

namespace PRUEBA.ADMIN.API.Middleware
{
    public class AuthenticationMiddleware
    {
        protected readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                var token = context.Request.GetToken();
                JwtSecurityToken tokenSecure = null;

                try
                {
                    tokenSecure = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                }
                catch (Exception)
                {
                    await EscribirRespuestaJson(context, StatusCodes.Status401Unauthorized, "Token no válido.");
                    return;
                }

                if (tokenSecure == null || tokenSecure.Payload == null)
                {
                    await EscribirRespuestaJson(context, StatusCodes.Status400BadRequest, "Payload no encontrado.");
                    return;
                }

                var Rol = PRUEBAConversions.NothingToString(tokenSecure.Payload["Rol"]);
                if (string.IsNullOrEmpty(Rol))
                {
                    await EscribirRespuestaJson(context, StatusCodes.Status400BadRequest, "Rol no encontrado.");
                    return;
                }

                var RolEnum = (PruebaRoles)Convert.ToInt32(Rol);
                var serviceName = context.Request.GetNameRequestServiceAndController();

                switch (RolEnum)
                {
                    case PruebaRoles.Usuario:
                        if (!CommonUtilities.NextMiddleware(ApiAdminConstants.GetServicesUsuario(), serviceName))
                        {
                            await next(context);
                            return;
                        }
                        else
                        {
                            await EscribirRespuestaJson(context, StatusCodes.Status403Forbidden, "Su rol no tiene acceso a esta acciòn.");
                            return;
                        }

                    case PruebaRoles.Supervisor:
                        if (!CommonUtilities.NextMiddleware(ApiAdminConstants.GetServicesSupervisor(), serviceName))
                        {
                            await next(context);
                            return;
                        }
                        else
                        {
                            await EscribirRespuestaJson(context, StatusCodes.Status403Forbidden, "Su rol no tiene acceso a esta acciòn.");
                            return;
                        }

                    default:
                        await EscribirRespuestaJson(context, StatusCodes.Status403Forbidden, $"Rol {RolEnum} no definido.");
                        return;
                }
            }
            catch (ArgumentNullException ex)
            {
                await EscribirRespuestaJson(context, StatusCodes.Status400BadRequest, PRUEBAUtilities.ExceptionToString(ex));
                return;
            } 
            catch (PruebaException ex)
            {
                await EscribirRespuestaJson(context, StatusCodes.Status400BadRequest, ex.Mensaje);
                return;
            }
            catch (Exception)
            {
                await EscribirRespuestaJson(context, StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción durante el proceso");
                return;
            }
        }

        // Método auxiliar para escribir una respuesta JSON
        private async Task EscribirRespuestaJson(HttpContext context, int statusCode, string mensaje)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var resultado = JsonSerializer.Serialize(new CredencialesLoginAppResultDto
            {
                MensajeRespuesta = mensaje,
                httpStatusCode = (HttpStatusCode)statusCode

            });

            await context.Response.WriteAsync(resultado);
        }

    }
}
