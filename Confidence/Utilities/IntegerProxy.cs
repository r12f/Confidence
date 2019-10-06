// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Globalization;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Proxy for accessing certain properties or functions of any type of integers.
    /// </summary>
    /// <typeparam name="T">Integer Type.</typeparam>
    public static class IntegerProxy<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "If GetCount cannot be created, this type cannot be used.")]
        static IntegerProxy()
        {
            BitwiseAnd = ExpressionBuilder.CreateBitwiseAndOperator<T>();

            if (BitwiseAnd == null)
            {
                string errorMessage = string.Format(CultureInfo.InvariantCulture, "{0} doesn't support bitwise and operator.", typeof(T).FullName);
                throw new InvalidOperationException(errorMessage);
            }
        }

        /// <summary>
        /// Function for getting Count property from the collection.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Needed.")]
        public static Func<T, T, T> BitwiseAnd { get; }
    }
}
