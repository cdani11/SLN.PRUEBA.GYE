using COM.PRUEBA.DOMAIN.Constans;
using COM.PRUEBA.DOMAIN.Tools;
using COM.PRUEBA.DOMAIN.Utilities;
using COM.PRUEBA.QUERY;
using COM.PRUEBA.QUERY.Parameters;
using COM.PRUEBA.QUERY.SERVICE;
using COM.PRUEBA.QUERY.SERVICE.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace PRUEBA.AUTH.API.ApiExtensions
{
    public static class ApiExtensions
    {
        public static string GetOnlyUrl(this HttpRequest request)
        {
            var url = request.GetDisplayUrl();
            var ServiceName = request.GetNameRequestServiceAndController();
            string index = "";
            index = !ServiceName.StartsWith("/") ? $"/{ServiceName.ToLower()}" : ServiceName.ToLower();
            var i = url.ToLower().IndexOf(index);
            url = url.Remove(i);
            if (url.EndsWith("/")) url = url.Remove(url.Length - 1);
            return url;
        }

        public static string GetNameRequestServiceAndController(this HttpRequest request)
        {
            string? action = string.Empty;
            string? requestName = string.Empty;
            action = request.Path.Value?.Trim();
            if (PRUEBAUtilities.DBNullToString(action).StartsWith("/"))
                requestName = action?.Remove(0, 1);
            else
                requestName = action;
            return requestName ?? string.Empty;
        }
    }
}
