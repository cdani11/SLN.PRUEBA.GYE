using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.interfaces
{
    public interface ILoginQueryService
    {
        Task<LoginQueryDto> Login(string Usuario, string ClaveEncriptada);
    }
}
