// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

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
        public static ValidateTarget<TValue> IsTrue<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<bool> assertion, Func<string> getErrorMessage = null)
        {
            if (assertion == null)
            {
                throw new ArgumentNullException(nameof(assertion));
            }

            if (!assertion.Invoke())
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrueOnCustomAssertion(target));
            }

            return target;
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
        public static ValidateTarget<TValue> Equal<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (!comparer.Equals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TValue> NotEqual<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (comparer.Equals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEqualTo(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TValue> IsDefault<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            TValue defaultValue = default(TValue);
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (!comparer.Equals(target.Value, defaultValue))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEqualTo(target, defaultValue));
            }

            return target;
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
        public static ValidateTarget<TValue> NotDefault<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Func<string> getErrorMessage = null, IEqualityComparer<TValue> customComparer = null)
        {
            TValue defaultValue = default(TValue);
            IEqualityComparer<TValue> comparer = customComparer ?? EqualityComparer<TValue>.Default;
            if (comparer.Equals(target.Value, defaultValue))
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
        public static ValidateTarget<TValue> IsType<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, Type valueToCompare, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeType(target, valueToCompare));
            }

            return target;
        }

#endif
    }
}