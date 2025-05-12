using COM.PRUEBA.DOMAIN.exception.DTOs;
using COM.PRUEBA.DOMAIN.exception;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using COM.PRUEBA.QUERY.interfaces;
using COM.PRUEBA.QUERY.SERVICE.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE.QueryServices
{
    public class AdminQueryService : BaseQueryService, IAdminQueryService
    {
        public AdminQueryService(IServiceScopeFactory serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<List<SolicitudPorEstadoQueryDto>> ConsultarSolicitudesPorEstado(int Estado)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                try
                {
                    return await pruebaQueryContext.ConsutlarSolicitudPorEstado(Estado);
                }
                catch (SqlException ex) when (ex.Number == 50001)
                {
                    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar las solicitudes del usuario.", ex);
                }
            }
        }

        public async Task<List<SolicitudQueryDto>> ConsultarSolicitudesPorUsuario(string Usuario)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                try
                {
                    return await pruebaQueryContext.ConsultarSolicitudesPorUsuario(Usuario);
                }
                catch (SqlException ex) when (ex.Number == 50001)
                {
                    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar las solicitudes del usuario.", ex);
                }
            }
        }

        public async Task<List<SolicitudQueryDto>> ConsultarSolicitudPorId(int idSolicitud)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                try
                {
                    return await pruebaQueryContext.ConsultarSolicitudPorId(idSolicitud);
                }
                catch (SqlException ex) when (ex.Number == 50001)
                {
                    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar las solicitudes del usuario.", ex);
                }
            }
        }

        public async Task<bool> RegistrarSolicitud(string descripcion, DateTime fechaSolicitud, int tipoCompra, int estado, string direccionSolicitante, string nombre, string usuario)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                    try
                    {
                        return await pruebaQueryContext.RegistrarSolicitud(descripcion, fechaSolicitud, tipoCompra, estado, direccionSolicitante, nombre, usuario);
                    }
                    catch (SqlException ex) when (ex.Number == 50001)
                    {
                        throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al consultar las solicitudes del usuario.", ex);
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> ActualizarSolicitud(long IdSolicitud, string descripcion, DateTime fechaSolicitud, int tipoCompra, int estado, string direccionSolicitante, string nombre, string usuario)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                    try
                    {
                        return await pruebaQueryContext.ActualizarSolicitud(IdSolicitud, descripcion, fechaSolicitud, tipoCompra, estado, direccionSolicitante, nombre, usuario);
                    }
                    catch (SqlException ex) when (ex.Number == 50001)
                    {
                        throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al consultar las solicitudes del usuario.", ex);
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> EliminarSolicitud(long IdSolicitud, string usuario)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();

                    try
                    {
                        return await pruebaQueryContext.EliminarSolicitud(IdSolicitud, usuario);
                    }
                    catch (SqlException ex) when (ex.Number == 50001)
                    {
                        throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = ex.Message });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al consultar las solicitudes del usuario.", ex);
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
