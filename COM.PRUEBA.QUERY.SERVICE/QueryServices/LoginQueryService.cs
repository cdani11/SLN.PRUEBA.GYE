using COM.PRUEBA.QUERY.DTOs;
using COM.PRUEBA.QUERY.DTOs.Shared;
using COM.PRUEBA.QUERY.interfaces;
using COM.PRUEBA.QUERY.SERVICE.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE.QueryServices
{
    public class LoginQueryService : BaseQueryService, ILoginQueryService
    {
        public LoginQueryService(IServiceScopeFactory serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<LoginQueryDto> Login(string Usuario, string ClaveEncriptada)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var pruebaQueryContext = scope.ServiceProvider.GetRequiredService<PruebaQueryContext>();
                return await pruebaQueryContext.Login(Usuario, ClaveEncriptada);
            }
        }
    }
}
