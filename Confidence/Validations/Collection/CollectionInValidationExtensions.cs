// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating is certain object in a collection.
    /// </summary>
    public static class CollectionInValidationExtensions
    {
        /// <summary>
        /// Validate if target is in a specific collection.
        /// </summary>
        /// <typeparam name="TItem">Child item type.</typeparam>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TItem> In<TItem, TCollection>([ValidatedNotNull] this ValidateTarget<TItem> target, TCollection valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (valueToCompare == null || !TypedCollectionProxy<TCollection, TItem>.Contains(valueToCompare, target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeIn(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not in a specific collection.
        /// </summary>
        /// <typeparam name="TItem">Child item type.</typeparam>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TItem> NotIn<TItem, TCollection>([ValidatedNotNull] this ValidateTarget<TItem> target, TCollection valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (valueToCompare != null && TypedCollectionProxy<TCollection, TItem>.Contains(valueToCompare, target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeIn(target));
            }

            return target;
        }
    }
}