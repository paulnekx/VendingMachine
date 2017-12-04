using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core.ExtensionMethods
{
    public static class Collection
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) 
            => collection != null && collection.Any();

        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer
                .GroupJoin(inner, outerKeySelector, innerKeySelector, (outerObj, inners) =>
                new
                {
                    outerObj,
                    inners = inners.DefaultIfEmpty()
                })
            .SelectMany(a => a.inners.Select(innerObj => resultSelector(a.outerObj, innerObj)));
        }

        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer
                .GroupJoin(inner, outerKeySelector, innerKeySelector, (outerObj, inners) =>
                new
                {
                    outerObj,
                    inners = inners.DefaultIfEmpty()
                }, comparer)
            .SelectMany(a => a.inners.Select(innerObj => resultSelector(a.outerObj, innerObj)));
        }
    }
}
