using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SLL.Extensions
{
	public static class StringExtensions
	{
        public static DateTime ToDate(this string input, bool throwExceptionIfFailed = false)
        {
            DateTime result;
            var valid = DateTime.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", input));
            return result;
        }

        public static int ToInt(this string input, bool throwExceptionIfFailed = false)
        {
            var valid = int.TryParse(input, out int result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as int", input));
            return result;
        }

        public static float ToFloat(this string input, bool throwExceptionIfFailed = false)
        {
            var valid = float.TryParse(input, out float result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as int", input));
            return result;
        }

        public static string Reverse(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var strLen = input.Length;
            var sb = new StringBuilder();
            for (int i = strLen - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        public static string GetLast(this string input, int howMany)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var value = input.Trim();
            return howMany >= value.Length ? value : value.Substring(value.Length - howMany);
        }

        public static bool IsInteger(this string input)
        {
            for (int i = 0; i != input.Length; i++)
            {
                var c = input[i];
                if (c == '-' && i == 0) { continue; }
                if (c < '0' || c > '9') { return false; }
            }
            return true;
        }

        public static bool IsNumeric(this string input)
        {
            float output;
            return float.TryParse(input, out output);
        }

        public static int ExtractNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var strNum = new StringBuilder();
            for (int i = 0; i != input.Length; i++)
            {
                var c = input[i];
                if (c < '0' || c > '9') 
                { 
                    if (strNum.Length == 0) { continue; }
                    else break;
                }
                strNum.Append(c);
            }
            return strNum.ToString().ToInt();
        }

        public static string RemoveLastCharacter(this String instr)
        {
            return instr.Substring(0, instr.Length - 1);
        }

        public static string RemoveLast(this String instr, int number)
        {
            return instr.Substring(0, instr.Length - number);
        }

        public static string RemoveFirstCharacter(this String instr)
        {
            return instr.Substring(1);
        }

        public static string RemoveFirst(this String instr, int number)
        {
            return instr.Substring(number);
        }

        public static Stream ToStream(this string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            return new MemoryStream(byteArray);
        }

    }
}
