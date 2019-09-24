// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating boolean.
    /// </summary>
    public static class BoolValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target is true.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool> IsTrue([ValidatedNotNull] this ValidateTarget<bool> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is true.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool?> IsTrue([ValidatedNotNull] this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not true (null or false).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool?> NotTrue([ValidatedNotNull] this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is false.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool> IsFalse([ValidatedNotNull] this ValidateTarget<bool> target, Func<string> getErrorMessage = null)
        {
            if (target.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeFalse(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is false.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool?> IsFalse([ValidatedNotNull] this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeFalse(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not false (null or true).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool?> NotFalse([ValidatedNotNull] this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && !target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeFalse(target));
            }

            return target;
        }
    }
}
