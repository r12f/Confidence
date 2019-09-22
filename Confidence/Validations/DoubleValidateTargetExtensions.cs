// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating double.
    /// </summary>
    public static class DoubleValidateTargetExtensions
    {
        /// <summary>
        /// Throw if double is not equal to the value to compare.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> Equal(this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Throw if double is equal to the value to compare.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotEqual(this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than an specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsLessThan(this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value >= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less or equal than an specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsLessOrEqualThan(this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value > valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is greater than an specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsGreaterThan(this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value <= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than an specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsGreaterOrEqualThan(this ValidateTarget<double> target, double valueToCompare, double allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
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
        public static ValidateTarget<double> InRange(this ValidateTarget<double> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<double?> InRange(this ValidateTarget<double?> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<double> NotInRange(this ValidateTarget<double> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<double?> NotInRange(this ValidateTarget<double?> target, double minValue, double maxValue, double allowedError, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<double> IsDefault(this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<double?> IsDefault(this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isDefaultValue = false;

            double defaultValue = default(double);
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - defaultValue);
                if (diff <= allowedError)
                {
                    isDefaultValue = true;
                }
            }

            if (!isDefaultValue)
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
        public static ValidateTarget<double> NotDefault(this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<double?> NotDefault(this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
        {
            bool isDefaultValue = false;

            double defaultValue = default(double);
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - defaultValue);
                if (diff <= allowedError)
                {
                    isDefaultValue = true;
                }
            }

            if (!isDefaultValue)
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
        public static ValidateTarget<double> IsNaN(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsNaN(target.Value))
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
        public static ValidateTarget<double> NotNaN(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsNaN(target.Value))
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
        public static ValidateTarget<double> IsInfinity(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsInfinity(target.Value))
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
        public static ValidateTarget<double> NotInfinity(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsInfinity(target.Value))
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
        public static ValidateTarget<double> IsPositiveInfinity(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsPositiveInfinity(target.Value))
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
        public static ValidateTarget<double> NotPositiveInfinity(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsPositiveInfinity(target.Value))
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
        public static ValidateTarget<double> IsNegativeInfinity(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (!double.IsNegativeInfinity(target.Value))
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
        public static ValidateTarget<double> NotNegativeInfinity(this ValidateTarget<double> target, Func<string> getErrorMessage = null)
        {
            if (double.IsNegativeInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(target));
            }

            return target;
        }
    }
}