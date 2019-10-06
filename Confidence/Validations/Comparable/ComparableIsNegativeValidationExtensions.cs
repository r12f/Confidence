// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// IsNegative validations.
    /// </summary>
    public static class ComparableIsNegativeValidationExtensions
    {
        /// <summary>
        /// Validate if target is negative.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsNegative<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            TValue valueToCompare = default(TValue);
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) >= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative. Null is counted as not negative as well.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsNegative<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            TValue valueToCompare = default(TValue);
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (!target.Value.HasValue || comparer.Compare(target.Value.Value, valueToCompare) >= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsNegative([ValidatedNotNull] this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            float valueToCompare = 0;
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value >= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative. Null is counted as not negative as well.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsNegative([ValidatedNotNull] this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = true;

            float valueToCompare = 0;
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError || target.Value.Value >= valueToCompare)
                {
                    isValidationFailed = false;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsNegative([ValidatedNotNull] this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
        {
            double valueToCompare = 0;
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value >= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative. Null is counted as not negative as well.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsNegative([ValidatedNotNull] this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = true;

            double valueToCompare = 0;
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError || target.Value.Value >= valueToCompare)
                {
                    isValidationFailed = false;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }
    }
}