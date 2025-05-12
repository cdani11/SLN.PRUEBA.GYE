using COM.PRUEBA.DOMAIN.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.Tools
{
    public static class PRUEBAConversions
    {

        public static string NothingToString(object Value)
        {
            if (Value == null)
            {
                return string.Empty;
            }

            return Convert.ToString(Value);
        }
        public static string DBNullToString(object Value)
        {
            if (Convert.IsDBNull(Value) || Value == null)
            {
                return string.Empty;
            }

            return Value?.ToString() ?? string.Empty;
        }

        public static string ExceptionToString(Exception Value)
        {
            try
            {
                string text = Value.Message;
                if (Value.InnerException != null)
                {
                    text = text + "-" + ExceptionToString(Value.InnerException);
                }

                return PRUEBAUtilities.QuitarSaltosLinea(text);
            }
            catch (Exception)
            {
            }

            return string.Empty;
        }

        public static byte DBNullToByte(object Value)
        {
            if (Convert.IsDBNull(Value))
            {
                return 0;
            }

            if (Value == null)
            {
                return 0;
            }

            if (IsNumeric(Value))
            {
                return Convert.ToByte(Value);
            }

            return 0;
        }

        public static string EnumtoString(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null && Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute)
                {
                    return descriptionAttribute.Description;
                }
            }

            return value.ToString();
        }

        public static bool IsNumeric(object Value)
        {
            try
            {
                double result;
                return double.TryParse(Value?.ToString(), out result);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static T? DeserializeJsonObject<T>(string str, ref string mensaje)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str)!;
            }
            catch (Exception ex)
            {
                mensaje = ExceptionToString(ex);
                return default;
            }
        }
    }
}
