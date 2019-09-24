// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating double.
    /// </summary>
    public static class DoubleValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target equals to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> Equal([ValidatedNotNull] this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target equals to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> Equal([ValidatedNotNull] this ValidateTarget<double?> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = true;

            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError)
                {
                    isValidationFailed = false;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't equal to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotEqual([ValidatedNotNull] this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't equal to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotEqual([ValidatedNotNull] this ValidateTarget<double?> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = false;

            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError)
                {
                    isValidationFailed = true;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsLessThan([ValidatedNotNull] this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value >= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsLessThan([ValidatedNotNull] this ValidateTarget<double?> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError || target.Value >= valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
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

        /// <summary>
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsGreaterThan([ValidatedNotNull] this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value <= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsGreaterThan([ValidatedNotNull] this ValidateTarget<double?> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError || target.Value <= valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater or equal a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsGreaterOrEqualThan([ValidatedNotNull] this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsGreaterOrEqualThan([ValidatedNotNull] this ValidateTarget<double?> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff > allowedError && target.Value < valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is within a range (larger or equal than min and less or equal than max).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> InRange([ValidatedNotNull] this ValidateTarget<double> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
        {
            var diffFromMin = Math.Abs(target.Value - minValue);
            var diffFromMax = Math.Abs(target.Value - maxValue);
            if ((diffFromMin > allowedError && target.Value < minValue) || (diffFromMax > allowedError && target.Value > maxValue))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(target, minValue, maxValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is within a range (larger or equal than min and less or equal than max). If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> InRange([ValidatedNotNull] this ValidateTarget<double?> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diffFromMin = Math.Abs(target.Value.Value - minValue);
                var diffFromMax = Math.Abs(target.Value.Value - maxValue);
                if ((diffFromMin > allowedError && target.Value.Value < minValue) || (diffFromMax > allowedError && target.Value.Value > maxValue))
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(target, minValue, maxValue));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not within a range (less than min and larger than max).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotInRange([ValidatedNotNull] this ValidateTarget<double> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
        {
            var diffFromMin = Math.Abs(target.Value - minValue);
            var diffFromMax = Math.Abs(target.Value - maxValue);
            if ((diffFromMin < allowedError || target.Value >= minValue) && (diffFromMax < allowedError || target.Value <= maxValue))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(target, minValue, maxValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not within a range (less than min and larger than max). If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotInRange([ValidatedNotNull] this ValidateTarget<double?> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diffFromMin = Math.Abs(target.Value.Value - minValue);
                var diffFromMax = Math.Abs(target.Value.Value - maxValue);
                if ((diffFromMin < allowedError || target.Value.Value >= minValue) && (diffFromMax < allowedError || target.Value.Value <= maxValue))
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(target, minValue, maxValue));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target equals to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsDefault([ValidatedNotNull] this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
        {
            double defaultValue = default(double);
            var diff = Math.Abs(target.Value - defaultValue);
            if (diff > allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target equals to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsDefault([ValidatedNotNull] this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = true;

            double defaultValue = default(double);
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - defaultValue);
                if (diff <= allowedError)
                {
                    isValidationFailed = false;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't equal to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotDefault([ValidatedNotNull] this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
        {
            double defaultValue = default(double);
            var diff = Math.Abs(target.Value - defaultValue);
            if (diff <= allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't equal to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotDefault([ValidatedNotNull] this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = false;

            double defaultValue = default(double);
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - defaultValue);
                if (diff <= allowedError)
                {
                    isValidationFailed = true;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsNaN([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsNaN(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNaN(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsNaN([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !double.IsNaN(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNaN(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotNaN([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsNaN(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNaN(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotNaN([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && double.IsNaN(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNaN(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsInfinity([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsInfinity([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !double.IsInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotInfinity([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotInfinity([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && double.IsInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsPositiveInfinity([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsPositiveInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBePositiveInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsPositiveInfinity([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !double.IsPositiveInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBePositiveInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotPositiveInfinity([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsPositiveInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBePositiveInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotPositiveInfinity([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && double.IsPositiveInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBePositiveInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsNegativeInfinity([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsNegativeInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNegativeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsNegativeInfinity([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !double.IsNegativeInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNegativeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotNegativeInfinity([ValidatedNotNull] this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsNegativeInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotNegativeInfinity([ValidatedNotNull] this ValidateTarget<double?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && double.IsNegativeInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(target));
            }

            return target;
        }
    }
}