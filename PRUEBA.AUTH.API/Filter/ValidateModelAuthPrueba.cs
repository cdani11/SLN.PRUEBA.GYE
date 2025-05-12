using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.DOMAIN.Utilities;
using COM.PRUEBA.DOMAIN.Extensions;

namespace PRUEBA.AUTH.API.Filter
{
    public class ValidateModelAuthPrueba : IActionFilter
    {


        public ValidateModelAuthPrueba()
        {
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            bool PasoValidacion = false;
            try
            {

                if (context.ActionArguments?.FirstOrDefault(x => x.Key == "credencialesLogin").Value == null)
                    throw new ArgumentNullException("Request no enviado.");

                var CredencialLogin = context.ActionArguments.FirstOrDefault(x => x.Key == "credencialesLogin").Value;

                if (CredencialLogin == null)
                    throw new ArgumentNullException(nameof(CredencialLogin), "El modelo no puede ser nulo");
                string errores = string.Empty;
                if (CredencialLogin is CredencialesLoginAppDto credenciales)
                    credenciales.Validar(out errores);
                else throw new Exception("Objeto invalido");

                if (!string.IsNullOrEmpty(errores))
                    throw new ArgumentNullException(errores);

                string mensaje = string.Empty;
                var resultCred = ObtenerCredenciales(context.HttpContext, ref mensaje);
                if (resultCred == null)
                {

                    throw new ArgumentNullException("No se puedieron obetener datos sobre el inicio de sesión");
                }
                else if ((bool)!resultCred)
                {
                    throw new ArgumentNullException(mensaje);
                }

                PasoValidacion = true;
            }
            catch (ArgumentNullException ex)
            {
                context.Result = new BadRequestObjectResult(new CredencialesLoginAppResultDto { MensajeRespuesta = PRUEBAUtilities.ExceptionToString(ex) });
                return;
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestObjectResult(new CredencialesLoginAppResultDto { MensajeRespuesta = "Ha ocurrido una excepción durante el proceso" });


                return;
            }
            finally
            {

            }
        }



        protected bool? ObtenerCredenciales(HttpContext HttpContext, ref string mensaje)
        {
            try
            {
                var Prefix = "Basic ";
                var AuthorizationHeader = HttpContext.Request.Headers[HeaderNames.Authorization];
                string decodedHeader = string.Empty;
                if (!string.IsNullOrEmpty(AuthorizationHeader))
                {
                    decodedHeader = AuthorizationHeader.ToString().StartsWith(Prefix, StringComparison.OrdinalIgnoreCase)
                        ? Encoding.UTF8.GetString(Convert.FromBase64String(AuthorizationHeader.ToString().Substring(Prefix.Length)))
                        : Encoding.UTF8.GetString(Convert.FromBase64String(AuthorizationHeader));
                }
                var credArray = decodedHeader.Split(':');
                if (credArray.Length < 2)
                {
                    mensaje = ("Credenciales no recibidas: " + decodedHeader);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }
    }
}
