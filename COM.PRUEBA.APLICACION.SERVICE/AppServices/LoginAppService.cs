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
    public class LoginAppService : ILoginAppServices
    {
        protected readonly ILoginQueryService loginQueryService;
        public LoginAppService(ILoginQueryService loginQueryService)
        {
            this.loginQueryService = loginQueryService;
        }
        public async Task<SharedAppResultDto<LoginQueryDto>> Login(CredencialesLoginAppDto credencialesLogin, string url)
        {
            var seccion = string.Empty;
            string mensaje = string.Empty;
            SharedAppResultDto<LoginQueryDto> resultApp = new();

            try
            {

                #region REALIZAR LOGIN
                string ClaveEncriptada = PRUEBACrypto.CifrarClave(credencialesLogin.Password, DomainConstants.PRUEBA_KEYENCRIPTA, DomainConstants.PRUEBA_SALTO);

                var result = await loginQueryService.Login(credencialesLogin.Usuario, ClaveEncriptada);
                #endregion

                #region VALIDAR ERRORES AL HACER LOGIN

                seccion = "VALIDAR ERRORES AL HACER LOGIN";
                if (result == null)
                {
                    mensaje = "Usuario o contraseña incorrecto, vuelva a intentarlo";
                    throw new PruebaValidacionesExeptions(new PruebaValidacionesExeptionsDto() { Mensaje = mensaje });

                }
                #endregion


                #region GENERAR TOKEN 

                var claims = new[]
                {
                    new Claim("UserId", result.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.Nombre),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DomainParameters.PRUEBA_JWT_KEY));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var audiencia = PRUEBAComponente.PruebaApiAuth.ToString();
                var fechaExpiracion = DateTime.Now.AddHours(DomainParameters.PRUEBA_JWT_EXPIRES);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    NotBefore = DateTime.Now,
                    Expires = fechaExpiracion,
                    Issuer = url.ToLower(),
                    Audience = audiencia,
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

                result.token = tokenHandler.WriteToken(securityToken);
                result.fechaExpiracion = fechaExpiracion;

                #endregion

                seccion = "GENERAR RESPUESTA";
                resultApp = new SharedAppResultDto<LoginQueryDto>
                {
                    Result = result,
                };
                return resultApp;


            }
            catch (PruebaValidacionesExeptions ex)
            {
                mensaje = $" {ex.pruebaValException?.Mensaje}";
                resultApp = new SharedAppResultDto<LoginQueryDto> { MensajeRespuesta = $"{mensaje}", Result = new LoginQueryDto() };
                return resultApp;
            }
            catch (PruebaException e)
            {
                mensaje = $"{e.Mensaje}";
                resultApp = new SharedAppResultDto<LoginQueryDto> { MensajeRespuesta = $"{mensaje}", Result = new LoginQueryDto() };
                return resultApp;

            }
            catch (Exception ex)
            {
                mensaje = $"{seccion} => {PRUEBAUtilities.ExceptionToString(ex)}";
                resultApp = new SharedAppResultDto<LoginQueryDto> { MensajeRespuesta = $"Ha ocurrido una excepción durante el proceso" };
                return resultApp;

            }

        }
    }
}
