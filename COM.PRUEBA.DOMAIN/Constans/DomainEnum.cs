using COM.PRUEBA.DOMAIN.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.Constans
{
    public enum PRUEBAComponente
    {
        [PruebaDetComponenteAttribute("CP001", "PRUEBA_PortalWeb")]
        PruebaPortalWeb,

        [PruebaDetComponenteAttribute("CP001", "PRUEBA_ApiAuth")]
        PruebaApiAuth,

        [PruebaDetComponenteAttribute("CP001", "PRUEBA_ApiAdmin")]
        PruebaApiAdmin
    }

    public enum PRUEBATipoORM : byte
    {
        EntityFramework = 1,
        Dapper = 2
    }

    public enum PRUEBAAmbiente : byte
    {
        [Description("pro")]
        Produccion = 1,
        [Description("qa")]
        Calidad = 2,
        [Description("dev")]
        Desarrollo = 3
    }

    public enum EstadoSolicitudes : int
    {
        [Description("Pendiente")]
        Pendiente = 1,
        [Description("Aprobada")]
        Aprobada = 2,
        [Description("Rechazada")]
        Rechazada = 3
    }

    public enum TipoCompra : int
    {
        [Description("Directa")]
        Directa = 1,
        [Description("Licitacion")]
        Licitacion = 2,
        [Description("Convenio")]
        Convenio = 3
    }

    public enum PruebaRoles : int
    {
        [Description("Usuario")]
        Usuario = 1,
        [Description("Supervisor")]
        Supervisor = 2,
    }
}
