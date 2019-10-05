// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating is any child item in collection matches predicate.
    /// </summary>
    public static class CollectionAnyValidationExtensions
    {
        /// <summary>
        /// Validate if target has any child item passes with predicate.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="predicate">Predicate for testing child items.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> Any<TCollection, TItem>([ValidatedNotNull] this ValidateTarget<TCollection> target, Func<TItem, bool> predicate, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            bool passedPredicate = false;
            if (target.Value != null)
            {
                foreach (var item in target.Value)
                {
                    if (predicate.Invoke(item))
                    {
                        passedPredicate = true;
                        break;
                    }
                }
            }

            if (!passedPredicate)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveAny(target));
            }

            return target;
        }

        /// <summary>
        /// Validate if target has any child item passes with predicate.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="predicate">Predicate for testing child items.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> UntypedAny<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, Func<object, bool> predicate, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            bool passedPredicate = false;
            if (target.Value != null)
            {
                foreach (var item in target.Value)
                {
                    if (predicate.Invoke(item))
                    {
                        passedPredicate = true;
                        break;
                    }
                }
            }

            if (!passedPredicate)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveAny(target));
            }

            return target;
        }
    }
}