// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating is collection child item count in a certain range.
    /// </summary>
    public static class CollectionCountInRangeValidationExtensions
    {
        /// <summary>
        /// Validate if the number of child items in target is in the specific range.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="min">Min count. The actual count should be larger or equal than this.</param>
        /// <param name="max">Max count. The actual count should be less or eqeual than this.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountIsInRange<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int min, int max, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            bool isValidationFailed = false;

            int collectionCount = 0;
            if (target.Value == null)
            {
                isValidationFailed = true;
            }
            else
            {
                collectionCount = CollectionProxy<TCollection>.GetCount(target.Value);
                if (collectionCount < min || collectionCount > max)
                {
                    isValidationFailed = true;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCountInRange(target, min, max));
            }

            return target;
        }

        /// <summary>
        /// Validate if the number of child items in target is not in the specific range.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="min">Min count. The actual count should be larger or equal than this.</param>
        /// <param name="max">Max count. The actual count should be less or eqeual than this.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountNotInRange<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int min, int max, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            bool isValidationFailed = true;

            int collectionCount = 0;
            if (target.Value == null)
            {
                isValidationFailed = false;
            }
            else
            {
                collectionCount = CollectionProxy<TCollection>.GetCount(target.Value);
                if (collectionCount < min || collectionCount > max)
                {
                    isValidationFailed = false;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCountInRange(target, min, max));
            }

            return target;
        }

        /// <summary>
        /// Validate if the number of child items in target is in the specific range.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="min">Min count. The actual count should be larger or equal than this.</param>
        /// <param name="max">Max count. The actual count should be less or eqeual than this.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountIsInRangeByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int min, int max, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            bool isValidationFailed = false;

            int collectionCount = 0;
            if (target.Value == null)
            {
                isValidationFailed = true;
            }
            else
            {
                collectionCount = CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, max + 1);
                if (collectionCount < min || collectionCount > max)
                {
                    isValidationFailed = true;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCountInRange(target, min, max));
            }

            return target;
        }

        /// <summary>
        /// Validate if the number of child items in target is not in the specific range.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="min">Min count. The actual count should be larger or equal than this.</param>
        /// <param name="max">Max count. The actual count should be less or eqeual than this.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ValidateTarget<TCollection> CountNotInRangeByEnumeration<TCollection>([ValidatedNotNull] this ValidateTarget<TCollection> target, int min, int max, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            bool isValidationFailed = true;

            int collectionCount = 0;
            if (target.Value == null)
            {
                isValidationFailed = false;
            }
            else
            {
                collectionCount = CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, max + 1);
                if (collectionCount < min || collectionCount > max)
                {
                    isValidationFailed = false;
                }
            }

            if (isValidationFailed)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCountInRange(target, min, max));
            }

            return target;
        }
    }
}