// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating ISet{T} overlaps with a specific set.
    /// </summary>
    public static class SetOverlapsValidationExtensions
    {
#if !NET35
        /// <summary>
        /// Validate if target overlaps with a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> Overlaps<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.Overlaps(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldOverlap(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't overlap with a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotOverlaps<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.Overlaps(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotOverlap(target));
                }
            }

            return target;
        }
#endif
    }
}
