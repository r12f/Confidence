// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating strings.
    /// </summary>
    public static class StringValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target is empty.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> IsEmpty(this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || target.Value.Length != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEmpty(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not empty.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> NotEmpty(this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && target.Value.Length == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(target));
            }

            return target;
        }

#if !NET35

        /// <summary>
        /// Validate if target is white space.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> IsWhiteSpace(this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || !string.IsNullOrWhiteSpace(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeWhiteSpace(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not white space.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> NotWhiteSpace(this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && string.IsNullOrWhiteSpace(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeWhiteSpace(target));
            }

            return target;
        }

#endif

        /// <summary>
        /// Validate if target starts with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> StartsWith(this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || !target.Value.StartsWith(valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldStartWith(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't start with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> NotStartsWith(this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && target.Value.StartsWith(valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotStartWith(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target ends with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> EndsWith(this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || !target.Value.EndsWith(valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldEndWith(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't end with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<string> NotEndsWith(this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && target.Value.EndsWith(valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotEndWith(target, valueToCompare));
            }

            return target;
        }
    }
}