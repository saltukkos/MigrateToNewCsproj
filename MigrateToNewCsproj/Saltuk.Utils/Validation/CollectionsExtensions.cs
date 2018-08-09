using System.Collections.Generic;
using JetBrains.Annotations;

namespace Saltuk.Utils.Validation
{
    public static class CollectionsExtensions
    {
        public static IEnumerable<T> WithNullChecking<T>([NotNull] this IEnumerable<T> enumerable) where T : class 
        {
            ThrowIf.Argument.IsNull(enumerable, nameof(enumerable));
            foreach (var item in enumerable)
            {
                if (item == null)
                {
                    ThrowHelper.ThrowArgumentNullException("Element of enumeration");
                }

                yield return item;
            }
        }

        public static IEnumerable<T> WithNullChecking<T>([NotNull] this List<T> list) where T : class 
        {
            ThrowIf.Argument.IsNull(list, nameof(list));
            foreach (var item in list)
            {
                if (item == null)
                {
                    ThrowHelper.ThrowArgumentNullException("Element of list");
                }

                yield return item;
            }
        }

    }
}