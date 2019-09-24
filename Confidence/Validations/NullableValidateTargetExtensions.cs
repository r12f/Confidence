// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        public static ref readonly ValidateTarget<TValue?> HasNoValue<TValue>(in this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            return ref NullableValidateTargetExtensions.IsNull(in target, getErrorMessage);
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
        public static ref readonly ValidateTarget<TValue?> IsNull<TValue>(in this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            if (target.Value.HasValue)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNull(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TValue?> HasValue<TValue>(in this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            return ref NullableValidateTargetExtensions.NotNull(in target, getErrorMessage);
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
        public static ref readonly ValidateTarget<TValue?> NotNull<TValue>(in this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct
        {
            if (!target.Value.HasValue)
            {
                ExceptionFactory.ThrowException(target.Traits.ObjectNullExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNull(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TValue?> Equal<TValue>(in this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
            where TValue : struct
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (!target.Value.HasValue || !comparer.Equals(target.Value.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, valueToCompare));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TValue?> NotEqual<TValue>(in this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
            where TValue : struct
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (target.Value.HasValue && comparer.Equals(target.Value.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }
    }
}