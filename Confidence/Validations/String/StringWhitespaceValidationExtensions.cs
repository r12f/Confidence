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
    public static class StringWhitespaceValidationExtensions
    {
#if !NET35

        /// <summary>
        /// Validate if target is white space.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> IsWhiteSpace([ValidatedNotNull] this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || !string.IsNullOrWhiteSpace(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeWhiteSpace(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not white space.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> NotWhiteSpace([ValidatedNotNull] this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && string.IsNullOrWhiteSpace(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeWhiteSpace(target));
            }

            return target;
        }

#endif
    }
}