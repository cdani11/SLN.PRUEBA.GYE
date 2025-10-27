using COM.PRUEBA.APLICACION.SERVICE.Constants;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.DOMAIN.exception;
using COM.PRUEBA.DOMAIN.Parameters;
using COM.PRUEBA.DOMAIN.Tools;
using COM.PRUEBA.DOMAIN.Utilities;
using COM.PRUEBA.QUERY.Parameters;
using COM.PRUEBA.QUERY.SERVICE;
using COM.PRUEBA.QUERY.SERVICE.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.COMMON.PRESENTACION.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string? DataSource, string? InitialCatalog, string? UserId, string? Password, long? Timeout, byte TipoOrm)
        {
            string mensaje = string.Empty;

            var BR_DataSource = PRUEBAConversions.DBNullToString(DataSource);
            var BR_InitialCatalog = PRUEBAConversions.DBNullToString(InitialCatalog);
            var BR_UserId = PRUEBAConversions.DBNullToString(UserId);
            var BR_Timeout = DomainConstants.PRUEBA_DB_TIMEOUT;

            var BRCadenaConexionEDOC = PRUEBAUtilities.CadenaConexion(BR_DataSource,
                                BR_InitialCatalog,
                                BR_UserId,
                                Password,
                                DomainConstants.PRUEBA_KEYENCRIPTA,
                                ref mensaje, BR_Timeout);

            if (BRCadenaConexionEDOC == null) throw new Exception("Cadena de conexión GSEDOC BR inválida");
            //ENTITY FRAMEWORK
            services.AddDbContext<PruebaQueryContextEF>(options => options.UseSqlServer(BRCadenaConexionEDOC));
            //DAPPER
            services.AddSingleton(s => new PruebaQueryContextDP(BRCadenaConexionEDOC));
            //CENTRAL
            services.AddScoped<PruebaQueryContext>();
            QueryParameters.TipoORM = (PRUEBATipoORM)PRUEBAConversions.DBNullToByte(TipoOrm);
            QueryParameters.ConnectionString = BRCadenaConexionEDOC;
            return services;
        }

        public static void AddSwaggerApp(this SwaggerGenOptions options, string schemeType = AppConstants.AUTH_SCHEMA_BEARER)
        {

            if (schemeType == AppConstants.AUTH_SCHEMA_BEARER)
            {
                options.AddSecurityDefinition(AppConstants.AUTH_SCHEMA_BEARER, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = AppConstants.AUTH_SCHEMA_BEARER,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT como: Bearer {token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = AppConstants.AUTH_SCHEMA_BEARER
                        }
                    },
                    Array.Empty<string>()
                }
            });
            }
            else if (schemeType == AppConstants.AUTH_SCHEMA_BASIC)
            {
                options.AddSecurityDefinition(AppConstants.AUTH_SCHEMA_BASIC, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = AppConstants.AUTH_SCHEMA_BASIC,
                    In = ParameterLocation.Header,
                    Description = "Autenticación básica (usuario y contraseña codificados en base64)"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = AppConstants.AUTH_SCHEMA_BASIC
                        }
                    },
                    Array.Empty<string>()
                }
            });
            }
            else
            {
                throw new ArgumentException("Tipo de esquema no soportado: use 'basic' o 'bearer'");
            }
        }

        public static AuthenticationBuilder AddPJwtAuthentication(this IServiceCollection services)
        {
            return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DomainParameters.PRUEBA_JWT_KEY)),
                        ValidateIssuer = true,
                        ValidIssuer = DomainParameters.PRUEBA_JWT_ISSUER.ToLower(),
                        ValidateAudience = true,
                        ValidAudience = PRUEBAComponente.PruebaApiAuth.ToString(),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"JWT Authentication failed: {context.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine($"JWT válido para: {context.Principal?.Identity?.Name}");
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public static string GetToken(this HttpRequest request)
        {
            string? Jwt = request.Headers[HeaderNames.Authorization];
            if (Jwt == null)
                throw new PruebaException("Authorization no encontrado");
            Jwt = Jwt?.Replace("Bearer", null)?.Trim();
            if (string.IsNullOrEmpty(Jwt))
                throw new PruebaException("Token no recibido");
            return Jwt;
        }

        public static IServiceCollection AddDevelopmentCors(this IServiceCollection services, string? UrlWebSitePortalConsulta)
        {

            if ((PRUEBAAmbiente)DomainParameters.APP_AMBIENTE == PRUEBAAmbiente.Desarrollo)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAngularDevelopment",
                        builder => builder.WithOrigins(UrlWebSitePortalConsulta)
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials());
                });

            }
            return services;
        }

        public static void UseCorsDevelopment(this WebApplication app)
        {
            if ((PRUEBAAmbiente)DomainParameters.APP_AMBIENTE == PRUEBAAmbiente.Desarrollo)
            {
                app.UseCors("AllowAngularDevelopment");
            }
        }

    }
}
