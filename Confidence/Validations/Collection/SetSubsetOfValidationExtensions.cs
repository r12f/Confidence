// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating ISet{T} is subset of with a specific set.
    /// </summary>
    public static class SetSubsetOfValidationExtensions
    {
#if !NET35
        /// <summary>
        /// Validate if target is a subset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> IsSubsetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSubsetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not a subset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotSubsetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSubsetOf(target));
                }
            }

            return target;
        }
#endif
    }
}