using COM.PRUEBA.APLICACION.DTOs.Admin;
using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.DOMAIN.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PRUEBA.ADMIN.API.Filter
{
    public class ValidateModelRegistroSolicitudesXUsuario : IActionFilter
    {
        public ValidateModelRegistroSolicitudesXUsuario()
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

                if (context.ActionArguments?.FirstOrDefault(x => x.Key == "Solicitud").Value == null)
                    throw new ArgumentNullException("Request no enviado.");

                var Solicitud = context.ActionArguments.FirstOrDefault(x => x.Key == "Solicitud").Value;

                if (Solicitud == null)
                    throw new ArgumentNullException(nameof(Solicitud), "El modelo no puede ser nulo");
                string errores = string.Empty;
                if (Solicitud is RegistroSolicitudAppDto credenciales)
                    credenciales.Validar(out errores);
                else throw new Exception("Objeto invalido");

                if (!string.IsNullOrEmpty(errores))
                    throw new ArgumentNullException(errores);

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

    }
}
