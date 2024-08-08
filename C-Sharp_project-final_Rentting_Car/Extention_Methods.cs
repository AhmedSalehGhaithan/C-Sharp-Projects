using System;
using System.Text.RegularExpressions;

namespace C_Sharp_project_final_Rentting_Car
{
    public static class Extention_Methods
    {
        // checking if the value is integer type
        public static bool IS_INTEGER_TYPE(this int value)
        {
            int result;
            return int.TryParse(value.ToString(), out result);
        }

        public static bool IsLongType(this long user_Value)
        {
            return true; // checking if the value is long type
        }
        public static bool IS_STRING_TYPEs(this string value)
        {
            string pattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(value.ToString(), pattern);
        }
        public static bool CHECKING_DOUBLE_INPUT(this double value)
        {
            bool resul = (value<=0)?false:true;
            return resul;
        }
        public static bool IsDateTimeType(this DateTime user_Value)
        {
            return true;  // checking if the value is Data type
        }

        public static bool IsDecimalType(this decimal user_Value)
        {
            bool resul = (user_Value < 0) ? false : true;
            return resul;  // checking if the value is Decimal type
        }

        public static bool IsEmptyInput(this string user_Value)
        {
            return string.IsNullOrEmpty(user_Value);  // checking if the value is empty input
        }

    }
}
