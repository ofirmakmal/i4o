using System.Globalization;

namespace IP.i4o
{
	internal static class StringExtensions
	{
		internal static string FormatWith(this string format, params object[] args)
		{
			return string.Format(format, args);
		}
	}
}