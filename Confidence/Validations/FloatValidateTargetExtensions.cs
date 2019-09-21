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
        /// Throw if float is not equal to the value to compare.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allow float error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> Equal(this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Throw if float is equal to the value to compare.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allow float error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> NotEqual(this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff <= allowedError)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is less than an specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="allowedError">Allow float error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsLessThan(this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        /// <param name="allowedError">Allow float error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsLessOrEqualThan(this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        /// <param name="allowedError">Allow float error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsGreaterThan(this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
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
        /// <param name="allowedError">Allow float error.</param>
        /// <param name="getErrorMessage">Error message builder.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Float, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<float> IsGreaterOrEqualThan(this ValidateTarget<float> target, float valueToCompare, float allowedError, Func<string> getErrorMessage = null)
        {
            var diff = Math.Abs(target.Value - valueToCompare);
            if (diff > allowedError && target.Value < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(target, valueToCompare));
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
        public static ValidateTarget<float> IsNaN(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsNaN(target.Value))
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
        public static ValidateTarget<float> NotNaN(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsNaN(target.Value))
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
        public static ValidateTarget<float> IsInfinity(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsInfinity(target.Value))
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
        public static ValidateTarget<float> NotInfinity(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsInfinity(target.Value))
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
        public static ValidateTarget<float> IsPositiveInfinity(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsPositiveInfinity(target.Value))
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
        public static ValidateTarget<float> NotPositiveInfinity(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsPositiveInfinity(target.Value))
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
        public static ValidateTarget<float> IsNegativeInfinity(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (!float.IsNegativeInfinity(target.Value))
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
        public static ValidateTarget<float> NotNegativeInfinity(this ValidateTarget<float> target, Func<string> getErrorMessage = null)
        {
            if (float.IsNegativeInfinity(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNegativeInfinity(target));
            }

            return target;
        }
    }
}