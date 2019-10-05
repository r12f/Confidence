// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating a float point number against positive infinity.
    /// </summary>
    public static class FloatPointNumberPositiveInfinityValidationExtensions
    {
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
    }
}