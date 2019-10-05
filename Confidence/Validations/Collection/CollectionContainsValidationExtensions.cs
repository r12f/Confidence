// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating is collection contains certain object.
    /// </summary>
    public static class CollectionContainsValidationExtensions
    {
        /// <summary>
        /// Validate if target contains specific item.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> Contains<TCollection, TItem>([ValidatedNotNull] this ValidateTarget<TCollection> target, TItem valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (target.Value == null || !TypedCollectionProxy<TCollection, TItem>.Contains(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldContain(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't contain specific item.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> DoesNotContain<TCollection, TItem>([ValidatedNotNull] this ValidateTarget<TCollection> target, TItem valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (target.Value != null && TypedCollectionProxy<TCollection, TItem>.Contains(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotContain(target, valueToCompare));
            }

            return target;
        }
    }
}