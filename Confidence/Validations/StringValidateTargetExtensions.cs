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
        public static ref readonly ValidateTarget<string> IsEmpty(in this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || target.Value.Length != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEmpty(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not empty.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<string> NotEmpty(in this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && target.Value.Length == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<string> IsWhiteSpace(in this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value == null || !string.IsNullOrWhiteSpace(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeWhiteSpace(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not white space.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<string> NotWhiteSpace(in this ValidateTarget<string> target, Func<string> getErrorMessage = null)
        {
            if (target.Value != null && string.IsNullOrWhiteSpace(target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeWhiteSpace(in target));
            }

            return ref target;
        }

#endif

        /// <summary>
        /// Validate if target starts with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<string> StartsWith(in this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (target.Value == null || !target.Value.StartsWith(valueToCompare, stringComparison))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldStartWith(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't start with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<string> NotStartsWith(in this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (target.Value != null && target.Value.StartsWith(valueToCompare, stringComparison))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotStartWith(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target ends with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<string> EndsWith(in this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (target.Value == null || !target.Value.EndsWith(valueToCompare, stringComparison))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldEndWith(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't end with specific value.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.String, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<string> NotEndsWith(in this ValidateTarget<string> target, string valueToCompare, Func<string> getErrorMessage = null, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (target.Value != null && target.Value.EndsWith(valueToCompare, stringComparison))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotEndWith(in target, valueToCompare));
            }

            return ref target;
        }
    }
}