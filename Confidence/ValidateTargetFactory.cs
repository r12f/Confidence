// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// ValidateTarget factory.
    /// </summary>
    /// <typeparam name="TException">Exception type used when validation failed.</typeparam>
    /// <typeparam name="TObjectNullException">Exception type used when object is null.</typeparam>
    /// <typeparam name="TOutOfRangeException">Exception type used when out of range.</typeparam>
    public class ValidateTargetFactory<TException, TObjectNullException, TOutOfRangeException>
        where TException : Exception
        where TObjectNullException : Exception
        where TOutOfRangeException : Exception
    {
        private static readonly ValidationTraits ValidationTraits = new ValidationTraits(typeof(TException), typeof(TObjectNullException), typeof(TOutOfRangeException));

        /// <summary>
        /// Create validation target.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>ValidateTarget.</returns>
        [DebuggerStepThrough]
        public ValidateTarget<T> Create<T>(T targetValue, string targetName)
        {
            return new ValidateTarget<T>(targetName, targetValue, ValidationTraits);
        }
    }
}
