using System;
using System.Linq.Expressions;

namespace IP.i4o
{
	internal static class ExpressionExtensions
	{
		internal static string GetMemberName<T, TProperty>(this Expression<Func<T, TProperty>> propertyExpression)
		{
			return ((MemberExpression)(propertyExpression.Body)).Member.Name;
		}
	}
}