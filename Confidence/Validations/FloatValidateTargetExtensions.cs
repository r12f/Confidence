// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

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
        public static ValidateTarget<float> Equal([ValidatedNotNull] this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> Equal([ValidatedNotNull] this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotEqual([ValidatedNotNull] this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotEqual([ValidatedNotNull] this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsLessThan([ValidatedNotNull] this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsLessThan([ValidatedNotNull] this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsGreaterThan([ValidatedNotNull] this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsGreaterThan([ValidatedNotNull] this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsGreaterOrEqualThan([ValidatedNotNull] this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsGreaterOrEqualThan([ValidatedNotNull] this ValidateTarget<float?> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsInRange([ValidatedNotNull] this ValidateTarget<float> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsInRange([ValidatedNotNull] this ValidateTarget<float?> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotInRange([ValidatedNotNull] this ValidateTarget<float> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotInRange([ValidatedNotNull] this ValidateTarget<float?> target, float minValue, float maxValue, float allowedError, Func<string> getErrorMessage = null)
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
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsDefault([ValidatedNotNull] this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            float defaultValue = default(float);
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
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsDefault([ValidatedNotNull] this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
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
        public static ValidateTarget<float> NotDefault([ValidatedNotNull] this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            float defaultValue = default(float);
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
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotDefault([ValidatedNotNull] this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target equals to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsZero([ValidatedNotNull] this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            return FloatValidateTargetExtensions.IsDefault(target, allowedError, getErrorMessage);
        }

        /// <summary>
        /// Validate if target equals to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsZero([ValidatedNotNull] this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
        {
            return FloatValidateTargetExtensions.IsDefault(target, allowedError, getErrorMessage);
        }

        /// <summary>
        /// Validate if target does not equal to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotZero([ValidatedNotNull] this ValidateTarget<float> target, float allowedError, Func<string> getErrorMessage = null)
        {
            return FloatValidateTargetExtensions.NotDefault(target, allowedError, getErrorMessage);
        }

        /// <summary>
        /// Validate if target does not equal to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed float point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotZero([ValidatedNotNull] this ValidateTarget<float?> target, float allowedError, Func<string> getErrorMessage = null)
        {
            return FloatValidateTargetExtensions.NotDefault(target, allowedError, getErrorMessage);
        }

        /// <summary>
        /// Validate if target is NaN.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsNaN([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsNaN(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsNaN([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsNaN(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotNaN([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsNaN(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotNaN([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsNaN(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsInfinity([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsInfinity(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsInfinity([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsInfinity(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotInfinity([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsInfinity(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotInfinity([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsInfinity(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsPositiveInfinity([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsPositiveInfinity(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsPositiveInfinity([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsPositiveInfinity(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotPositiveInfinity([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsPositiveInfinity(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotPositiveInfinity([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsPositiveInfinity(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsNegativeInfinity([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsNegativeInfinity(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> IsNegativeInfinity([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !float.IsNegativeInfinity(target.Value.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotNegativeInfinity([ValidatedNotNull] this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsNegativeInfinity(target.Value))
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
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float?> NotNegativeInfinity([ValidatedNotNull] this ValidateTarget<float?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && float.IsNegativeInfinity(target.Value.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(target));
            }

            return target;
        }
    }
}