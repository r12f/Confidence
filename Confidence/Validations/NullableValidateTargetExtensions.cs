// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating nullable objects.
    /// </summary>
    public static class NullableValidateTargetExtensions
    {
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
            return NullableValidateTargetExtensions.IsNull(target, getErrorMessage);
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
            return NullableValidateTargetExtensions.NotNull(target, getErrorMessage);
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
        /// Validate if target equals to a specified object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.NullableObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> Equal<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
            where TValue : struct
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (!target.Value.HasValue || !comparer.Equals(target.Value.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't equal to a specific object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.NullableObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> NotEqual<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
            where TValue : struct
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (target.Value.HasValue && comparer.Equals(target.Value.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
        }
    }
}