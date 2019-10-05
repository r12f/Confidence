// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// IsLessOrEqualThan validations.
    /// </summary>
    public static class ComparableIsLessOrEqualThanValidationExtensions
    {
        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsLessOrEqualThan<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) > 0)
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
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsLessOrEqualThan<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) > 0)
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
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsLessOrEqualThan<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) > 0)
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
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsLessOrEqualThan<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsLessOrEqualThan([ValidatedNotNull] this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value > valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsLessOrEqualThan([ValidatedNotNull] this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff > allowedError && target.Value > valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsLessOrEqualThan([ValidatedNotNull] this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value > valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsLessOrEqualThan([ValidatedNotNull] this ValidateTarget<double?> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff > allowedError && target.Value > valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }
    }
}