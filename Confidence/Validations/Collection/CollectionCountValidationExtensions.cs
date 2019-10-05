// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating collection child item count.
    /// </summary>
    public static class CollectionCountValidationExtensions
    {
        /// <summary>
        /// Validate if target has expected number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountIs<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCount(target.Value) != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCount(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target has expected number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountIsByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCount(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't have specific number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountNot<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCount(target.Value) == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveCount(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't have specific number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountNotByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveCount(target, valueToCompare));
            }

            return target;
        }
    }
}