using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.DTOs.Shared
{
    public class SharedAppResultDto<T>
    {
        public T? Result { set; get; }
        public string? CodigoRespuesta { get; set; }
        public string? MensajeRespuesta { get; set; }



        public override string ToString()
        {
            return $"Result: [{Result}]  Mensaje Respuesta: [{MensajeRespuesta}]";
        }
    }
}
