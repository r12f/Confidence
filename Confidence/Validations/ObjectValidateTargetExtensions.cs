﻿// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating object.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "Prefer better grouping than ordering.")]
    public static class ObjectValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target equals to another object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> Equal<TValue>(this ValidateTarget<TValue> target, TValue valueToCompare, IEqualityComparer<TValue> customComparer = null, Func<string> getErrorMessage = null)
        {
            IEqualityComparer<TValue> comparer = customComparer ?? (IEqualityComparer<TValue>)EqualityComparer<TValue>.Default;
            if (!comparer.Equals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't equal to another object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> NotEqual<TValue>(this ValidateTarget<TValue> target, TValue valueToCompare, IEqualityComparer<TValue> customComparer = null, Func<string> getErrorMessage = null)
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (comparer.Equals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
        }

#if !NETSTANDARD1_0

        /// <summary>
        /// Validate if target is an object of specific type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Type)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsType<TValue>(this ValidateTarget<TValue> target, Type valueToCompare, Func<string> getErrorMessage = null)
        {
            var targetType = typeof(TValue);
            if (target.Value != null)
            {
                targetType = target.Value.GetType();
            }

            if (!valueToCompare.IsAssignableFrom(targetType))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeType(target, valueToCompare));
            }

            return target;
        }

#endif
    }
}