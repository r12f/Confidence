// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating an object against null.
    /// </summary>
    public static class ObjectNullValidationExtensions
    {
        /// <summary>
        /// Validate if target is null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.ClassObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsNull<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (target.Value != null)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNull(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.NullableObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsNull<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            if (target.Value.HasValue)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNull(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.NullableObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> DoesNotHaveValue<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            return ObjectNullValidationExtensions.IsNull(target, getErrorMessage);
        }

        /// <summary>
        /// Validate if target is not null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.ClassObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> NotNull<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (target.Value == null)
            {
                ExceptionFactory.ThrowException(target.Traits.ObjectNullExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNull(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.NullableObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> NotNull<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            if (!target.Value.HasValue)
            {
                ExceptionFactory.ThrowException(target.Traits.ObjectNullExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNull(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.NullableObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> HasValue<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            return ObjectNullValidationExtensions.NotNull(target, getErrorMessage);
        }
    }
}
