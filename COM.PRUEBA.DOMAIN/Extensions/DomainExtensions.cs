using COM.PRUEBA.DOMAIN.Attributes;
using COM.PRUEBA.DOMAIN.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.Extensions
{
    public static class DomainExtensions
    {
        public static string GetNombre(this PRUEBAComponente obj)
        {
            try
            {
                var det = obj.GetAttribute<PruebaDetComponenteAttribute>();
                return det.Nombre ?? string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string GetCaller(this object obj, [CallerMemberName] string memberName = "")
        {
            return obj.GetType().Name.Split('`')[0] + "." + memberName;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First()
                .GetCustomAttribute<TAttribute>();
        }

       
    }
}
