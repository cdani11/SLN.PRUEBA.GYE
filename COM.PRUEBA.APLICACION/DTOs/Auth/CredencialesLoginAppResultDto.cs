using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace COM.PRUEBA.APLICACION.DTOs.Auth
{
    public class CredencialesLoginAppResultDto
    {
        public bool Result { set; get; }
        public string MensajeRespuesta { set; get; }
        public HttpStatusCode httpStatusCode { set; get; }

        public override string ToString()
        {
            return $"Http estado: [{httpStatusCode}] Result: [{Result}]  Mensaje Respuesta: [{MensajeRespuesta}]";
        }
    }
}
