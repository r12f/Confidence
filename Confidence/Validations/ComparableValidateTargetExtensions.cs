// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating IComparable objects.
    /// </summary>
    public static class ComparableValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target is less than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsLessThan<TValue>(this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable
        {
            if (target.Value.CompareTo(valueToCompare) >= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsLessThan<TValue>(this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                if (target.Value.Value.CompareTo(valueToCompare) >= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsLessThan<TValue>(this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable<TValue>
        {
            if (Comparer<TValue>.Default.Compare(target.Value, valueToCompare) >= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsLessThan<TValue>(this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                if (Comparer<TValue>.Default.Compare(target.Value.Value, valueToCompare) >= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsLessOrEqualThan<TValue>(this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable
        {
            if (target.Value.CompareTo(valueToCompare) > 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsLessOrEqualThan<TValue>(this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                if (target.Value.Value.CompareTo(valueToCompare) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsLessOrEqualThan<TValue>(this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable<TValue>
        {
            if (Comparer<TValue>.Default.Compare(target.Value, valueToCompare) > 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsLessOrEqualThan<TValue>(this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                if (Comparer<TValue>.Default.Compare(target.Value.Value, valueToCompare) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsGreaterThan<TValue>(this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable
        {
            if (target.Value.CompareTo(valueToCompare) <= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsGreaterThan<TValue>(this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                if (target.Value.Value.CompareTo(valueToCompare) <= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsGreaterThan<TValue>(this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable<TValue>
        {
            if (Comparer<TValue>.Default.Compare(target.Value, valueToCompare) <= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsGreaterThan<TValue>(this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                if (Comparer<TValue>.Default.Compare(target.Value.Value, valueToCompare) <= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsGreaterOrEqualThan<TValue>(this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable
        {
            if (target.Value.CompareTo(valueToCompare) < 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsGreaterOrEqualThan<TValue>(this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                if (target.Value.Value.CompareTo(valueToCompare) < 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsGreaterOrEqualThan<TValue>(this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : IComparable<TValue>
        {
            if (Comparer<TValue>.Default.Compare(target.Value, valueToCompare) < 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsGreaterOrEqualThan<TValue>(this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                if (Comparer<TValue>.Default.Compare(target.Value.Value, valueToCompare) < 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }
    }
}