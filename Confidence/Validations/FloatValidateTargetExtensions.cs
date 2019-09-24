// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating float.
    /// </summary>
    public static class FloatValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target equals to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> Equal(in this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target equals to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> Equal(in this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't equal to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotEqual(in this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't equal to a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotEqual(in this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsLessThan(in this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value >= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsLessThan(in this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError || target.Value >= valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(in target, valueToCompare));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<float> IsLessOrEqualThan(in this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value > valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(in target, valueToCompare));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<float?> IsLessOrEqualThan(in this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff > allowedError && target.Value > valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsGreaterThan(in this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError || target.Value <= valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsGreaterThan(in this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff <= allowedError || target.Value <= valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater or equal a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsGreaterOrEqualThan(in this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsGreaterOrEqualThan(in this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diff = Math.Abs(target.Value.Value - valueToCompare);
                if (diff > allowedError && target.Value < valueToCompare)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(in target, valueToCompare));
                }
            }

            return ref target;
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> InRange(in this ValidateTarget<float> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
        {
            var diffFromMin = Math.Abs(target.Value - minValue);
            var diffFromMax = Math.Abs(target.Value - maxValue);
            if ((diffFromMin > allowedError && target.Value < minValue) || (diffFromMax > allowedError && target.Value > maxValue))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(in target, minValue, maxValue));
            }

            return ref target;
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> InRange(in this ValidateTarget<float?> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diffFromMin = Math.Abs(target.Value.Value - minValue);
                var diffFromMax = Math.Abs(target.Value.Value - maxValue);
                if ((diffFromMin > allowedError && target.Value.Value < minValue) || (diffFromMax > allowedError && target.Value.Value > maxValue))
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(in target, minValue, maxValue));
                }
            }

            return ref target;
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotInRange(in this ValidateTarget<float> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
        {
            var diffFromMin = Math.Abs(target.Value - minValue);
            var diffFromMax = Math.Abs(target.Value - maxValue);
            if ((diffFromMin < allowedError || target.Value >= minValue) && (diffFromMax < allowedError || target.Value <= maxValue))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(in target, minValue, maxValue));
            }

            return ref target;
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotInRange(in this ValidateTarget<float?> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue)
            {
                var diffFromMin = Math.Abs(target.Value.Value - minValue);
                var diffFromMax = Math.Abs(target.Value.Value - maxValue);
                if ((diffFromMin < allowedError || target.Value.Value >= minValue) && (diffFromMax < allowedError || target.Value.Value <= maxValue))
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(in target, minValue, maxValue));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target equals to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsDefault(in this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            float defaultValue = default(float);
            var diff = Math.Abs(target.Value - defaultValue);
            if (diff > allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, defaultValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target equals to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsDefault(in this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = true;

            float defaultValue = default(float);
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, defaultValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't equal to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotDefault(in this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            float defaultValue = default(float);
            var diff = Math.Abs(target.Value - defaultValue);
            if (diff <= allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(in target, defaultValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't equal to the default value of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotDefault(in this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
        {
            bool isValidationFailed = false;

            float defaultValue = default(float);
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(in target, defaultValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsNaN(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsNaN(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNaN(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsNaN(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsNaN(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNaN(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotNaN(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsNaN(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNaN(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotNaN(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsNaN(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNaN(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsInfinity(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsInfinity(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotInfinity(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotInfinity(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsPositiveInfinity(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsPositiveInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBePositiveInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsPositiveInfinity(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsPositiveInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBePositiveInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotPositiveInfinity(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsPositiveInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBePositiveInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not positive infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotPositiveInfinity(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsPositiveInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBePositiveInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> IsNegativeInfinity(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsNegativeInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNegativeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> IsNegativeInfinity(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsNegativeInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNegativeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float> NotNegativeInfinity(in this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsNegativeInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not negative infinity.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<float?> NotNegativeInfinity(in this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsNegativeInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(in target));
            }

            return ref target;
        }
    }
}