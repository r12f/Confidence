// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// IsTrue/NotTrue validations.
    /// </summary>
    public static class ObjectTrueValidateExtensions
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
        /// Validate if target is true.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool> IsTrue([ValidatedNotNull] this ValidateTarget<bool> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is true.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool?> IsTrue([ValidatedNotNull] this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (!target.Value.HasValue || !target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not true (null or false).
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Boolean, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<bool?> NotTrue([ValidatedNotNull] this ValidateTarget<bool?> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.HasValue && target.Value.Value)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue(target));
            }

            return target;
        }
    }
}