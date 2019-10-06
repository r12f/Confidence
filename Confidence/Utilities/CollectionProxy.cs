// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Globalization;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Proxy for accessing certain properties or functions of any type of collections.
    /// </summary>
    /// <typeparam name="T">Collection Type.</typeparam>
    public static class CollectionProxy<T>
        where T : IEnumerable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "If GetCount cannot be created, this type cannot be used.")]
        static CollectionProxy()
        {
            GetCount = ExpressionBuilder.CreatePropertyGetter<T, int>("Count");

            if (GetCount == null)
            {
                GetCount = ExpressionBuilder.CreatePropertyGetter<T, int>("Length");
            }

            if (GetCount == null)
            {
                string errorMessage = string.Format(CultureInfo.InvariantCulture, "{0} doesn't have Count or Length property. Please implement either one of them to use this validation.", typeof(T).FullName);
                throw new InvalidOperationException(errorMessage);
            }
        }

        /// <summary>
        /// Function for getting Count property from the collection.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Needed.")]
        public static Func<T, int> GetCount { get; }

        /// <summary>
        /// Get collection child count by enumeration.
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="maxEnumerationSteps">Max enumeration steps.</param>
        /// <returns>Collection child item count.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Needed.")]
        public static int GetCountByEnumeration(T collection, int maxEnumerationSteps)
        {
            int count = 0;
            var enumerator = collection.GetEnumerator();
            while (count < maxEnumerationSteps && enumerator.MoveNext())
            {
                ++count;
            }

            return count;
        }
    }
}