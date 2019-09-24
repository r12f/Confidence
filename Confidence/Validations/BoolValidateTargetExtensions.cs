// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

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
        public static ref readonly ValidateTarget<bool> IsTrue(in this ValidateTarget<bool> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is true.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<bool?> IsTrue(in this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not true (null or false).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<bool?> NotTrue(in this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is false.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<bool> IsFalse(in this ValidateTarget<bool> target, Func<string> getErrorMessage = null)
        {
            if (target.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeFalse(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is false.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<bool?> IsFalse(in this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeFalse(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not false (null or true).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<bool?> NotFalse(in this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && !target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeFalse(in target));
            }

            return ref target;
        }
    }
}
