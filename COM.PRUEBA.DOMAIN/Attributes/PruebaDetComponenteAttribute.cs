using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace COM.PRUEBA.DOMAIN.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class PruebaDetComponenteAttribute : DescriptionAttribute
    {
        public PruebaDetComponenteAttribute(string Codigo, string? Nombre)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
        }

        public string Codigo { get; set; }
        public string? Nombre { get; set; }
    }
}
