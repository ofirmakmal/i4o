using System.Collections.Generic;

namespace IP.i4o
{
	internal static class SortedListExtensions
	{
		/// <summary>
		/// This is an optimized implementation of IndexOfKey method to return the index of the key equal to
		/// or the first index greater than the specified key.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="sortedList"></param>
		/// <param name="key"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		internal static bool TryFindIndex<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey key, out int index)
		{
			var comparer = sortedList.Comparer;
			int lb = 0, ub = sortedList.Count;

			index = ub / 2;
			while (ub > lb)
			{
				int compareResult = comparer.Compare(sortedList.Keys[index], key);

				if (compareResult == 0)
				{
					return true;
				}
				else if (compareResult > 0)
				{
					ub = index;
				}
				else
				{
					lb = index + 1;
				}

				index = lb + (ub - lb) / 2;
			}

			return false;
		}

		internal static IEnumerable<TKey> WhereLessThan<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey key)
		{
			int index;
			if (!sortedList.TryFindIndex(key, out index))
			{
				index--;
			}

			for (int i = 0; i < index; i++)
			{
				yield return sortedList.Keys[i];
			}

			yield break;
		}

		internal static IEnumerable<TKey> WhereLessThanOrEqualTo<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey key)
		{
			int index;
			if (!sortedList.TryFindIndex(key, out index))
			{
				index--;
			}

			for (int i = 0; i <= index; i++)
			{
				yield return sortedList.Keys[i];
			}

			yield break;
		}

		internal static IEnumerable<TKey> WhereGreaterThan<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey key)
		{
			int index;
			if (sortedList.TryFindIndex(key, out index))
			{
				index++;
			}

			for (int i = index; i < sortedList.Count; i++)
			{
				yield return sortedList.Keys[i];
			}

			yield break;
		}

		internal static IEnumerable<TKey> WhereGreaterThanOrEqualTo<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey key)
		{
			int index;
			sortedList.TryFindIndex(key, out index);

			for (int i = index; i < sortedList.Count; i++)
			{
				yield return sortedList.Keys[i];
			}

			yield break;
		}
	}
}