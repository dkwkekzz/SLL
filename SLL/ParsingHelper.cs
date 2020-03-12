using System;
using System.Collections.Generic;

namespace SLL
{
	public static class ParsingHelper
	{
		public struct Token
		{
			public string[] Tokens;
			public int Index;

			public string Next
			{
				get
				{
					if (null == Tokens) { return null; }
					if (Tokens.Length <= Index) { return null; }
					return Tokens[Index++];
				}
			}
		}

		public static Token Make(this string _src, char _token)
		{
			var token = new Token();
			token.Tokens = string.IsNullOrEmpty(_src) ? null : _src.Split(_token);
			token.Index = 0;
			return token;
		}

		public static Token Next(this Token _src, ref int _val1)
		{
			var current = _src.Next;
			if (!string.IsNullOrEmpty(current))
			{
				_val1 = int.Parse(current);
			}

			return _src;
		}

		public static Token Next(this Token _src, ref float _val1)
		{
			var current = _src.Next;
			if (!string.IsNullOrEmpty(current))
			{
				_val1 = float.Parse(current);
			}

			return _src;
		}

		public static Token Next(this Token _src, ref string _val1)
		{
			var current = _src.Next;
			if (!string.IsNullOrEmpty(current))
			{
				_val1 = current;
			}

			return _src;
		}

		public static Token Next(this Token _src, out int _val1, int _defaultVal = 0)
		{
			var current = _src.Next;
			if (!string.IsNullOrEmpty(current))
			{
				_val1 = int.Parse(current);
			}
			else
			{
				_val1 = _defaultVal;
			}

			return _src;
		}
		
		public static Token Next(this Token _src, out float _val1, float _defaultVal = 0f)
		{
			var current = _src.Next;
			if (!string.IsNullOrEmpty(current))
			{
				_val1 = float.Parse(current);
			}
			else
			{
				_val1 = _defaultVal;
			}

			return _src;
		}

		public static Token Next(this Token _src, out string _val1, string _defaultVal = "")
		{
			var current = _src.Next;
			if (!string.IsNullOrEmpty(current))
			{
				_val1 = current;
			}
			else
			{
				_val1 = _defaultVal;
			}

			return _src;
		}

		public static bool Parse<T1>(this string _src, char _token, ref T1 _val1)
		{
			if (string.IsNullOrEmpty(_src))
			{
				return false;
			}

			var splited = _src.Split(_token);
			if (splited.Length >= 1)
			{
				var subSrc = splited[0];
				_val1 = (T1)Convert.ChangeType(subSrc, typeof(T1));
			}

			return true;
		}

		public static bool Parse<T1, T2>(this string _src, char _token, ref T1 _val1, ref T2 _val2)
		{
			if (string.IsNullOrEmpty(_src))
			{
				return false;
			}

			var splited = _src.Split(_token);
			if (splited.Length >= 1)
			{
				var subSrc = splited[0];
				_val1 = (T1)Convert.ChangeType(subSrc, typeof(T1));
			}
			if (splited.Length >= 2)
			{
				var subSrc = splited[1];
				_val2 = (T2)Convert.ChangeType(subSrc, typeof(T2));
			}

			return true;
		}

		public static bool Parse<T1, T2, T3>(this string _src, char _token, ref T1 _val1, ref T2 _val2, ref T3 _val3)
		{
			if (string.IsNullOrEmpty(_src))
			{
				return false;
			}

			var splited = _src.Split(_token);
			if (splited.Length >= 1)
			{
				var subSrc = splited[0];
				_val1 = (T1)Convert.ChangeType(subSrc, typeof(T1));
			}
			if (splited.Length >= 2)
			{
				var subSrc = splited[1];
				_val2 = (T2)Convert.ChangeType(subSrc, typeof(T2));
			}
			if (splited.Length >= 3)
			{
				var subSrc = splited[2];
				_val3 = (T3)Convert.ChangeType(subSrc, typeof(T3));
			}

			return true;
		}
	}

}
