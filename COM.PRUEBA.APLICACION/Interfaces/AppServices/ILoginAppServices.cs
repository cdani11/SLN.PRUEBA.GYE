using COM.PRUEBA.APLICACION.DTOs.Auth;
using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.APLICACION.Interfaces.AppServices
{
    public interface ILoginAppServices
    {
        Task<SharedAppResultDto<LoginQueryDto>> Login(CredencialesLoginAppDto credencialesLogin, string url);
    }
}
