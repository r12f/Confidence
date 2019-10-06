// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating the target type.
    /// </summary>
    public static class ObjectTypeValidationExtensions
    {
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