using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace COM.PRUEBA.APLICACION.DTOs.Auth
{
    public class CredencialesLoginAppDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

        public bool Validar(out string errores)
        {
            errores = string.Empty;
            if (string.IsNullOrWhiteSpace(Password))
            {
                errores += "Password es obligatorio \n";
            }


            if (string.IsNullOrWhiteSpace(Usuario))
            {
                errores += "Usuario es obligatorio \n";
            }

            return string.IsNullOrEmpty(errores);
        }
    }
}
