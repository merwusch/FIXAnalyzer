using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIXAnalyzer
{
    public static class GlobalExtensions
    {
        public static double ToDouble(this string value)
        {
            double result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            string decSep = (1.00 / 2.00).ToString().Substring(1, 1);
            value = value.Replace(",", decSep);
            value = value.Replace(".", decSep);

            //value = value.Trim().Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
            //  .Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            double.TryParse(value, out result);

            return result;
        }

        public static decimal ToSpecialDecimal(this string value)
        {
            decimal result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            if( value.Contains(",") && value.Contains(".") )
            {
                var index1 = value.LastIndexOf(",", StringComparison.Ordinal);
                var index2 = value.LastIndexOf(".", StringComparison.Ordinal);

                var deleteSep = index1 < index2 ? "," : ".";
                value = value.Replace(deleteSep, "");
            }

            string decSep = (1.00m / 2.00m).ToString().Substring(1, 1);
            value = value.Replace(",", decSep);
            value = value.Replace(".", decSep);

            //value = value.Trim().Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
            //  .Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            decimal.TryParse(value, out result);

            return result;
        }

        public static decimal ToDecimal(this string value)
        {
            decimal result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            string decSep = (1.00m / 2.00m).ToString().Substring(1, 1);
            value = value.Replace(",", decSep);
            value = value.Replace(".", decSep);

            //value = value.Trim().Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
            //  .Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            decimal.TryParse(value, out result);

            return result;
        }

        public static float ToFloat(this string value)
        {
            float result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            value = value.Trim().Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
              .Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            float.TryParse(value, out result);

            return result;
        }

        public static long ToInt64(this string value)
        {
            long result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            long.TryParse(value.Trim(), out result);

            return result;
        }

        public static int ToInt32(this string value)
        {
            int result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            int.TryParse(value.Trim(), out result);

            return result;
        }

        public static short ToInt16(this string value)
        {
            short result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            short.TryParse(value.Trim(), out result);

            return result;
        }

        public static DateTime ToDateTime(this string value)
        {
            DateTime result = DateTime.MinValue;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            DateTime.TryParse(value.Trim(), out result);

            return result;
        }

        public static byte ToByte(this string value)
        {
            byte result = 0;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            byte.TryParse(value.Trim(), out result);

            return result;
        }

        public static bool ToBoolean(this string value)
        {
            bool result = false;

            if( string.IsNullOrWhiteSpace(value) ) return result;

            if( !bool.TryParse(value.Trim(), out result) )
                result = value == "1";

            return result;
        }


    }
}
