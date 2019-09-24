// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating objects.
    /// </summary>
    public static class ClassValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target is null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.ClassObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsNull<TValue>(in this ValidateTarget<TValue> target, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (target.Value != null)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeNull(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not null.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.ClassObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> NotNull<TValue>(in this ValidateTarget<TValue> target, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (target.Value == null)
            {
                ExceptionFactory.ThrowException(target.Traits.ObjectNullExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeNull(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is the same reference to another object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.ClassObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsSame<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (!object.ReferenceEquals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSame(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not the same reference to another object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.ClassObject, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> NotSame<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (object.ReferenceEquals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSame(in target, valueToCompare));
            }

            return ref target;
        }
    }
}