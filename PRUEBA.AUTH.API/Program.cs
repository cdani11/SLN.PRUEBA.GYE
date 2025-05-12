using COM.PRUEBA.APLICACION.SERVICE.Constants;
using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.DOMAIN.Parameters;
using COM.PRUEBA.DOMAIN.Tools;
using COM.PRUEBA.DOMAIN.Utilities;
using Microsoft.OpenApi.Models;
using PRUEBA.AUTH.API.ApiExtensions;
using PRUEBA.AUTH.API.Filter;
using PRUEBA.AUTH.API.Settings;
using COM.PRUEBA.DOMAIN.Extensions;
using COM.PRUEBA.QUERY.interfaces;
using COM.PRUEBA.QUERY.SERVICE.QueryServices;
using COM.PRUEBA.APLICACION.Interfaces.AppServices;
using COM.PRUEBA.APLICACION.SERVICE.AppServices;
using PRUEBA.COMMON.PRESENTACION.Extensions;

Settings settings = new();
var builder = WebApplication.CreateBuilder(args);

try
{
    DomainParameters.APP_COMPONENTE = PRUEBAComponente.PruebaApiAuth;
    DomainParameters.APP_NOMBRE = $"{DomainParameters.APP_COMPONENTE.GetNombre()} v{AppConstants.Version}";

    #region LOAD SETTINGS
    DomainParameters.APP_AMBIENTE = PRUEBAAmbiente.Desarrollo;
    LoadSettings(ref settings);
    #endregion

    #region INJECT DATABASE
    builder.Services.AddDatabase(
        settings.GSEDOC_BR.DataSource,
        settings.GSEDOC_BR.InitialCatalog,
        settings.GSEDOC_BR.UserId,
        settings.GSEDOC_BR.Password,
        settings.GSEDOC_BR.Timeout,
        settings.GSEDOC_BR.TipoORM);
    #endregion

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = DomainParameters.APP_NOMBRE, Version = AppConstants.Version });
        c.AddSwaggerApp(AppConstants.AUTH_SCHEMA_BASIC);
    });

    #region INJECT SERVICES
    builder.Services.AddScoped<ILoginAppServices, LoginAppService>();
    builder.Services.AddScoped<ILoginQueryService, LoginQueryService>();
    #endregion

    #region INJECT FILTERS
    builder.Services.AddScoped<ValidateModelAuthPrueba>();
    #endregion

    builder.Services.AddDevelopmentCors(DomainParameters.PRUEBA_URL_PORTAL);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("AllowAngularDevelopment");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(PRUEBAUtilities.ExceptionToString(ex));
}

void LoadSettings(ref Settings settings)
{
    PRUEBAUtilities.SetCultureInfo(DomainConstants.PRUEBA_CULTUREINFO);
    string? mensaje = string.Empty;
    string? jsonSettings = File.ReadAllText(PRUEBAUtilities.GetFileNameAppSettings());
    settings = PRUEBAConversions.DeserializeJsonObject<Settings>(jsonSettings, ref mensaje)!;
    DomainParameters.PRUEBA_JWT_KEY = settings.Jwt.Key;
    DomainParameters.PRUEBA_JWT_EXPIRES = settings.Jwt.expires ?? 2;
    DomainParameters.PRUEBA_URL_PORTAL = settings.UrlWebSitePortalConsulta;
    if (settings == null) throw new Exception(mensaje);
}
