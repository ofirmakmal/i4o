﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IP.i4o
{
	public interface IIndex<TChild> : ICollection<TChild>
	{
		IEnumerable<TChild> WhereThroughIndex(Expression<Func<TChild, bool>> whereClause);

		void Reset(TChild changedObject);
	}
}