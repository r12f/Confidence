// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating strings.
    /// </summary>
    public static class StringEndsWithValidationExtensions
    {
        /// <summary>
        /// Validate if target ends with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> EndsWith([ValidatedNotNull] this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (target.Value == null || !target.Value.EndsWith(valueToCompare, stringComparison))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldEndWith(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't end with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> DoesNotEndWith([ValidatedNotNull] this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (target.Value != null && target.Value.EndsWith(valueToCompare, stringComparison))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotEndWith(target, valueToCompare));
            }

            return target;
        }
    }
}