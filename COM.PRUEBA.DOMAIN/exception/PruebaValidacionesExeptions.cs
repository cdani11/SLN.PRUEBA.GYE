using COM.PRUEBA.DOMAIN.exception.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.exception
{
    public class PruebaValidacionesExeptions: Exception
    {
        public PruebaValidacionesExeptions(PruebaValidacionesExeptionsDto pruebaValException)
        {
            this.pruebaValException = pruebaValException;
        }

        public PruebaValidacionesExeptionsDto pruebaValException { get; }
    }
}
