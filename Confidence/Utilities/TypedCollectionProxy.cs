// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Proxy for accessing certain properties or functions of any type of collections.
    /// </summary>
    /// <typeparam name="T">Collection type.</typeparam>
    /// <typeparam name="TItem">Collection child item type.</typeparam>
    public static class TypedCollectionProxy<T, TItem>
        where T : IEnumerable<TItem>
    {
        static TypedCollectionProxy()
        {
            Contains = ExpressionBuilder.CreateMethodWithOneArgsInvoker<T, TItem, bool>("Contains");

            if (Contains == null)
            {
                Contains = ContainsByEnumeration;
            }
        }

        /// <summary>
        /// Function pointer to Contains.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Needed.")]
        public static Func<T, TItem, bool> Contains { get; }

        /// <summary>
        /// Check if collection contains certain item by enumeration.
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="valueToCompare">Object to find.</param>
        /// <returns>True, if object is found.</returns>
        private static bool ContainsByEnumeration(T collection, TItem valueToCompare)
        {
            var comparer = EqualityComparer<TItem>.Default;
            foreach (var item in collection)
            {
                if (comparer.Equals(item, valueToCompare))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
