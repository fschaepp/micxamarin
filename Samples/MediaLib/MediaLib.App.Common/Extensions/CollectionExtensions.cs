using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaLib.App.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection.Where(predicate).ToList())
            {
                collection.Remove(item);
            }
        }

        public static void RemoveSingle<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            collection.Remove(collection.Single(predicate));
        }
    }
}
