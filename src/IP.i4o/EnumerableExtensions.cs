using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace IP.i4o
{
	public static class EnumerableExtensions
	{
		internal static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
		{
			if (sequence == null) throw new ArgumentNullException("sequence");
			if (action == null) throw new ArgumentNullException("action");

			foreach (var item in sequence)
			{
				action(item);
			}
		}
	}
}