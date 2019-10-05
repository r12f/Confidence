// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating strings.
    /// </summary>
    public static class StringLengthValidationExtensions
    {
        /// <summary>
        /// Validate if target length matches a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> LengthIs([ValidatedNotNull] this ValidateTarget<string> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            // As other string API does in C#, null is smaller than empty, so the length of null is not 0.
            if (target.Value == null || target.Value.Length != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveLength(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target length doesn't match a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> LengthNot([ValidatedNotNull] this ValidateTarget<string> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            // As other string API does in C#, null is smaller than empty, so the length of null is not 0.
            if (target.Value != null && target.Value.Length == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveLength(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target length is larger or equal than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> LengthMin([ValidatedNotNull] this ValidateTarget<string> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            // As other string API does in C#, null is smaller than empty, so the length of null is not 0.
            if (target.Value == null || target.Value.Length < valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveMinLength(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target length is less or equal than a specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> LengthMax([ValidatedNotNull] this ValidateTarget<string> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            // As other string API does in C#, null is smaller than empty, so the length of null is not 0.
            if (target.Value == null || target.Value.Length > valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveMaxLength(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target length is in a specific range.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="min">Min length. The actual length should be larger or equal than this.</param>
        /// <param name="max">Max length. The actual length should be less or eqeual than this.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> LengthIsInRange([ValidatedNotNull] this ValidateTarget<string> target, int min, int max, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || target.Value.Length < min || target.Value.Length > max)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveLengthInRange(target, min, max));
            }

            return target;
        }

        /// <summary>
        /// Validate if target length is not in a specific range.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="min">Min length. The actual length should be larger or equal than this.</param>
        /// <param name="max">Max length. The actual length should be less or eqeual than this.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> LengthNotInRange([ValidatedNotNull] this ValidateTarget<string> target, int min, int max, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && target.Value.Length >= min && target.Value.Length <= max)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveLengthInRange(target, min, max));
            }

            return target;
        }
    }
}