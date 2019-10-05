// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating collection min child item count.
    /// </summary>
    public static class CollectionCountMinValidationExtensions
    {
        /// <summary>
        /// Validate if target child item count is larger or equal than a specific value.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountMin<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCount(target.Value) < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveMinCount(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target child item count is larger or equal than a specific value.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountMinByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveMinCount(target, valueToCompare));
            }

            return target;
        }
    }
}