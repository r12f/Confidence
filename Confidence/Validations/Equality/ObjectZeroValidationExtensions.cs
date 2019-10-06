// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating an object against the zero value of its type.
    /// </summary>
    public static class ObjectZeroValidationExtensions
    {
        /// <summary>
        /// Validate if target equals to zero of its type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> IsZero<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null)
            where TValue : struct, IEquatable<TValue>
        {
            TValue defaultValue = default(TValue);
            if (!target.Value.Equals(defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target equals to zero of its type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> IsZero<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct, IEquatable<TValue>
        {
            TValue defaultValue = default(TValue);
            if (!target.Value.HasValue || !target.Value.Equals(defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
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
            return ObjectDefaultValidationExtensions.IsDefault(target, allowedError, getErrorMessage);
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
        /// Validate if target equals to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> IsZero([ValidatedNotNull] this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
        {
            return ObjectDefaultValidationExtensions.IsDefault(target, allowedError, getErrorMessage);
        }

        /// <summary>
        /// Validate if target equals to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> IsZero([ValidatedNotNull] this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
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
        /// Validate if target does not equal to zero of its type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue> NotZero<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null)
            where TValue : struct, IEquatable<TValue>
        {
            TValue defaultValue = default(TValue);
            if (target.Value.Equals(defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
        }

        /// <summary>
        /// Validate if target does not equal to zero of its type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<TValue?> NotZero<TValue>([ValidatedNotNull] this ValidateTarget<TValue?> target, Func<string> getErrorMessage = null)
            where TValue : struct, IEquatable<TValue>
        {
            TValue defaultValue = default(TValue);
            if (!target.Value.HasValue && target.Value.Equals(defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
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
            return ObjectDefaultValidationExtensions.NotDefault(target, allowedError, getErrorMessage);
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
        /// Validate if target does not equal to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double> NotZero([ValidatedNotNull] this ValidateTarget<double> target, double allowedError, Func<string> getErrorMessage = null)
        {
            return ObjectDefaultValidationExtensions.NotDefault(target, allowedError, getErrorMessage);
        }

        /// <summary>
        /// Validate if target does not equal to zero of its type.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="allowedError">Allowed double point error.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Double, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<double?> NotZero([ValidatedNotNull] this ValidateTarget<double?> target, double allowedError, Func<string> getErrorMessage = null)
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
    }
}