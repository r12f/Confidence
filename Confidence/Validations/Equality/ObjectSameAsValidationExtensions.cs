// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions used for validating if the target is the same object as another one.
    /// </summary>
    public static class ObjectSameAsValidationExtensions
    {
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
        public static ValidateTarget<TValue> IsSameAs<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (!object.ReferenceEquals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSame(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TValue> NotSameAs<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : class
        {
            if (object.ReferenceEquals(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSame(target, valueToCompare));
            }

            return target;
        }
    }
}