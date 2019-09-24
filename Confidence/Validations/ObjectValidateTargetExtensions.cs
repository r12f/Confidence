// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating object.
    /// </summary>
    public static class ObjectValidateTargetExtensions
    {
        /// <summary>
        /// Validate if a custom assertion returns true.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="assertion">Custom assertion.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsTrue<TValue>(in this ValidateTarget<TValue> target, Func<bool> assertion, Func<string> getErrorMessage = null)
        {
            if (assertion == null)
            {
                throw new ArgumentNullException(nameof(assertion));
            }

            if (!assertion.Invoke())
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrueOnCustomAssertion(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target equals to a specified object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> Equal<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (!comparer.Equals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't equal to a specific object.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> NotEqual<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (comparer.Equals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target equals to the default value of its type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsDefault<TValue>(in this ValidateTarget<TValue> target, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            TValue defaultValue = default(TValue);
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (!comparer.Equals(target.Value, defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, defaultValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target not equals to the default value of its type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> NotDefault<TValue>(in this ValidateTarget<TValue> target, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            TValue defaultValue = default(TValue);
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (comparer.Equals(target.Value, defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(in target, defaultValue));
            }

            return ref target;
        }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1

        /// <summary>
        /// Validate if target is an object of specific type.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Object, ValidationMethodTypes.Type)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsType<TValue>(in this ValidateTarget<TValue> target, Type valueToCompare, Func<string> getErrorMessage = null)
        {
            if (valueToCompare == null)
            {
                throw new ArgumentNullException(nameof(valueToCompare));
            }

            var targetType = typeof(TValue);
            if (target.Value != null)
            {
                targetType = target.Value.GetType();
            }

            if (!valueToCompare.IsAssignableFrom(targetType))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeType(in target, valueToCompare));
            }

            return ref target;
        }

#endif
    }
}