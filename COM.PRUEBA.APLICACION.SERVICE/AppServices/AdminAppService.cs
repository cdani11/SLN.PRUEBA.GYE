using COM.PRUEBA.APLICACION.DTOs.Admin;
using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.APLICACION.Interfaces.AppServices;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.DOMAIN.exception;
using COM.PRUEBA.DOMAIN.exception.DTOs;
using COM.PRUEBA.DOMAIN.Extensions;
using COM.PRUEBA.DOMAIN.Parameters;
using COM.PRUEBA.DOMAIN.Tools;
using COM.PRUEBA.DOMAIN.Utilities;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using COM.PRUEBA.QUERY.interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace COM.PRUEBA.APLICACION.SERVICE.AppServices
{
    public class AdminAppService : IAdminAppServices
    {
        protected readonly IAdminQueryService adminQueryService;
        public AdminAppService(IAdminQueryService adminQueryService)
        {
            this.adminQueryService = adminQueryService;
        }

        public async Task<SharedAppResultDto<bool>> AprobarSolicitud(AprobarSolicitud SolicitudAprobador)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<bool> resultApp = new();

            try
            {

                var solicitud = await adminQueryService.ConsultarSolicitudPorId(SolicitudAprobador.idSolicitud);
                if (solicitud == null || solicitud.Count == 0)
                {
                    mensaje = "No existe una solicitud registrada...";
                    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = mensaje });
                }

                //if (solicitud.First().Monto >= DomainParameters.PRUEBA_MONTOMAXIMO_VALIDACION && SolicitudAprobador.Descripcin == string.Empty)
                //{
                //    mensaje = $"Para montos supereriores a ${DomainParameters.PRUEBA_MONTOMAXIMO_VALIDACION} se debe ingresar una descripción";
                //    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = mensaje });
                //}


                seccion = "GENERAR RESPUESTA";
                resultApp = new SharedAppResultDto<bool>
                {
                    Result = true,

                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso" };
                return resultApp;

            }
        }

        public async Task<SharedAppResultDto<List<SolicitudPorEstadoQueryDto>>> ConsultarSolicitudesPorEstado(int Estado)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<List<SolicitudPorEstadoQueryDto>> resultApp = new();

            try
            {

                var result = await adminQueryService.ConsultarSolicitudesPorEstado(Estado);
                seccion = "GENERAR RESPUESTA";


                resultApp = new SharedAppResultDto<List<SolicitudPorEstadoQueryDto>>
                {
                    Result = result,

                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<List<SolicitudPorEstadoQueryDto>> { MensajeRespuesta = $"{mensaje}", Result = new List<SolicitudPorEstadoQueryDto>() };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<List<SolicitudPorEstadoQueryDto>> { MensajeRespuesta = $"{mensaje}", Result = new List<SolicitudPorEstadoQueryDto>() };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<List<SolicitudPorEstadoQueryDto>> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso" };
                return resultApp;

            }
        }

        public async Task<SharedAppResultDto<List<SolicitudQueryDto>>> ConsultarSolicitudesPorUsuario(string Usuario)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<List<SolicitudQueryDto>> resultApp = new();

            try
            {

                var result = await adminQueryService.ConsultarSolicitudesPorUsuario(Usuario);
                seccion = "GENERAR RESPUESTA";


                resultApp = new SharedAppResultDto<List<SolicitudQueryDto>>
                {
                    Result = result,

                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<List<SolicitudQueryDto>> { MensajeRespuesta = $"{mensaje}", Result = new List<SolicitudQueryDto>() };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<List<SolicitudQueryDto>> { MensajeRespuesta = $"{mensaje}", Result = new List<SolicitudQueryDto>() };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<List<SolicitudQueryDto>> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso" };
                return resultApp;

            }
        }

        public async Task<SharedAppResultDto<bool>> RegistrarSolicitud(RegistroSolicitudAppDto Solicitud)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<bool> resultApp = new();

            try
            {

                var result = await adminQueryService.RegistrarSolicitud(Solicitud.Descripcion, Solicitud.FechaSolucitud.Value, (int)Solicitud.TipoCompra, (int)Solicitud.Estado, Solicitud.DireccionSolicitante, Solicitud.Nombre, Solicitud.Usuario);
                seccion = "GENERAR RESPUESTA";


                resultApp = new SharedAppResultDto<bool>
                {
                    Result = result,

                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso", Result = false };
                return resultApp;

            }
        }


        public async Task<SharedAppResultDto<bool>> ActualizarSolicitud(ActualizarSolicitudAppDto Solicitud)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<bool> resultApp = new();

            try
            {

                var result = await adminQueryService.ActualizarSolicitud(Solicitud.id, Solicitud.Descripcion, Solicitud.FechaSolucitud.Value, (int)Solicitud.TipoCompra, (int)Solicitud.Estado, Solicitud.DireccionSolicitante, Solicitud.Nombre, Solicitud.Usuario);
                seccion = "GENERAR RESPUESTA";


                resultApp = new SharedAppResultDto<bool>
                {
                    Result = result,

                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso", Result = false };
                return resultApp;

            }
        }

        public async Task<SharedAppResultDto<bool>> EliminarSolicitud(long idSoliciutd, string Usuario)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<bool> resultApp = new();

            try
            {

                var result = await adminQueryService.EliminarSolicitud(idSoliciutd, Usuario);
                seccion = "GENERAR RESPUESTA";


                resultApp = new SharedAppResultDto<bool>
                {
                    Result = result,

                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"{mensaje}", Result = false };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<bool> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso", Result = false };
                return resultApp;

            }
        }


    }
}
