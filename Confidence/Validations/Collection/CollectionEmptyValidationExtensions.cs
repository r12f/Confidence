// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating is a collection empty.
    /// </summary>
    public static class CollectionEmptyValidationExtensions
    {
        /// <summary>
        /// Validate if target is empty.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> IsEmpty<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCount(target.Value) != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEmpty(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is empty.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> IsEmptyByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, 1) != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEmpty(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not empty.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> NotEmpty<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCount(target.Value) == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not empty.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> NotEmptyByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, 1) == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(target));
            }

            return target;
        }
    }
}