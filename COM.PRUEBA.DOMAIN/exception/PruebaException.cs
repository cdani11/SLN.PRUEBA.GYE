using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.exception
{
    public class PruebaException : Exception
    {
        public PruebaException(string? Mensaje)
        {
            this.Mensaje = Mensaje;
            this.Excepcion = new Exception(Mensaje);
        }
        public PruebaException(string? Mensaje, Exception? Excepcion)
        {
            this.Mensaje = Mensaje;
            this.Excepcion = Excepcion;
        }

        public string? Mensaje { get; }
        public Exception? Excepcion { get; }
    }
}
