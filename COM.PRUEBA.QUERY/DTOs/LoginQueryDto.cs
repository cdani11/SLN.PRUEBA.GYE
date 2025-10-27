using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.DTOs
{
    public class LoginQueryDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }        
        public string Apellido { get; set; }      
        public string Email { get; set; }         
        public bool Estado { get; set; }
        public string? token { get; set; }
        public DateTime? fechaExpiracion { get; set; }
    }
}
