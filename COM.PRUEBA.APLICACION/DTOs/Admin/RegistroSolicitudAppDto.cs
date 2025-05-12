using COM.PRUEBA.DOMAIN.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.APLICACION.DTOs.Admin
{
    public class RegistroSolicitudAppDto
    {
        public string? DireccionSolicitante { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }
        //public decimal Monto { get; set; }
        //public DateTime FechaEsperada { get; set; }
        public EstadoSolicitudes Estado { get; set; }
        public TipoCompra TipoCompra { get; set; }
        public DateTime? FechaSolucitud { get; set; }
        public string? Usuario { get; set; }

        public bool Validar(out string errores)
        {
            var listaErrores = new List<string>();

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                listaErrores.Add("Nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(DireccionSolicitante))
            {
                listaErrores.Add("Dirección del solicitante es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                listaErrores.Add("Descripción es obligatoria.");
            }

            //if (Monto <= 0)
            //{
            //    listaErrores.Add("Monto debe ser mayor a 0.");
            //}

            //if (FechaEsperada == default)
            //{
            //    listaErrores.Add("Fecha esperada es obligatoria.");
            //}

            if (FechaSolucitud == null || FechaSolucitud == default)
            {
                listaErrores.Add("Fecha de solicitud es obligatoria.");
            }

            if (!Enum.IsDefined(typeof(EstadoSolicitudes), Estado))
            {
                listaErrores.Add("Estado de la solicitud no es válido.");
            }

            if (!Enum.IsDefined(typeof(TipoCompra), TipoCompra))
            {
                listaErrores.Add("Tipo de compra no es válido.");
            }

            if (string.IsNullOrWhiteSpace(Usuario))
            {
                listaErrores.Add("Usuario es obligatorio.");
            }

            errores = string.Join("\n", listaErrores);
            return listaErrores.Count == 0;
        }
    }
}
