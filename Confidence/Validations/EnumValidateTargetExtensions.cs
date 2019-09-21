// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating enum.
    /// </summary>
    public static class EnumValidateTargetExtensions
    {
#if !NET35
        /// <summary>
        /// Validate if target has specific flag.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToComapre">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Enum, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> HasFlag<TValue>(this ValidateTarget<TValue> target, TValue valueToComapre, Func<string> getErrorMessage = null)
            where TValue : struct, Enum
        {
            if (!target.Value.HasFlag(valueToComapre))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveFlag(target, valueToComapre));
            }

            return target;
        }

        /// <summary>
        /// Validate if target has specific flag.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToComapre">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Enum, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> HasNoFlag<TValue>(this ValidateTarget<TValue> target, TValue valueToComapre, Func<string> getErrorMessage = null)
            where TValue : struct, Enum
        {
            if (target.Value.HasFlag(valueToComapre))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveFlag(target, valueToComapre));
            }

            return target;
        }
#endif
    }
}
