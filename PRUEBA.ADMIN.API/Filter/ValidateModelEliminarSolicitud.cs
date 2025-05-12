using COM.PRUEBA.APLICACION.DTOs.Admin;
using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.DOMAIN.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PRUEBA.ADMIN.API.Filter
{
    public class ValidateModelEliminarSolicitud : IActionFilter
    {
        public ValidateModelEliminarSolicitud()
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

                if (context.ActionArguments?.FirstOrDefault(x => x.Key == "idSolicitud").Value == null)
                    throw new ArgumentNullException("Request no enviado.");

                var idSolicitud = context.ActionArguments.FirstOrDefault(x => x.Key == "idSolicitud").Value;

                if (idSolicitud == null)
                    throw new ArgumentNullException(nameof(idSolicitud), "El idSolicitud no puede ser nulo");

                if (context.ActionArguments?.FirstOrDefault(x => x.Key == "Usuario").Value == null)
                    throw new ArgumentNullException("Request no enviado.");

                var Usuario = context.ActionArguments.FirstOrDefault(x => x.Key == "Usuario").Value;

                if (idSolicitud == null)
                    throw new ArgumentNullException(nameof(idSolicitud), "El Usuario no puede ser nulo");

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
