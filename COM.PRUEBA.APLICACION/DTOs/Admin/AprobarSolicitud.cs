using COM.PRUEBA.DOMAIN.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.APLICACION.DTOs.Admin
{
    public class AprobarSolicitud
    {
        public int idSolicitud { get; set; }
        public string Descripcin { get; set; }
        public EstadoSolicitudes Estado { get; set; }

        public bool Validar(out string errores)
        {
            var listaErrores = new List<string>();

           
            if (idSolicitud <= 0)
            {
                listaErrores.Add("Id de la solicitud debe ser mayor a 0.");
            }

            // Validar si el estado es un valor definido del enum
            if (!Enum.IsDefined(typeof(EstadoSolicitudes), Estado))
            {
                listaErrores.Add("El estado seleccionado no es válido.");
            }

            errores = string.Join("\n", listaErrores);
            return listaErrores.Count == 0;
        }
    }
}
