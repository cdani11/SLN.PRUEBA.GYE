using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.DOMAIN.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PRUEBA.ADMIN.API.Filter
{
    public class ValidateModelConsultaSolicitudes : IActionFilter
    {
        public ValidateModelConsultaSolicitudes()
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

                if (context.ActionArguments?.FirstOrDefault(x => x.Key == "Usuario").Value == null)
                    throw new ArgumentNullException("Request no enviado.");

                var Usuario = context.ActionArguments.FirstOrDefault(x => x.Key == "Usuario").Value;

                if (Usuario == null)
                    throw new ArgumentNullException(nameof(Usuario), "El modelo no puede ser nulo");
               

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
