// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating IDictionary{T}.
    /// </summary>
    public static class DictionaryValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target contains specific key.
        /// </summary>
        /// <typeparam name="TDictionary">Target type.</typeparam>
        /// <typeparam name="TKey">Dictionary key type.</typeparam>
        /// <typeparam name="TValue">Dictionary value type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Dictionary, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TDictionary> ContainsKey<TDictionary, TKey, TValue>(this ValidateTarget<TDictionary> target, TKey valueToCompare, Func<string> getErrorMessage = null)
            where TDictionary : IDictionary<TKey, TValue>
        {
            if (target.Value == null || !target.Value.ContainsKey(valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldContain(target, valueToCompare));
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't contain specific key.
        /// </summary>
        /// <typeparam name="TDictionary">Target type.</typeparam>
        /// <typeparam name="TKey">Dictionary key type.</typeparam>
        /// <typeparam name="TValue">Dictionary value type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Dictionary, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TDictionary> NotContainsKey<TDictionary, TKey, TValue>(this ValidateTarget<TDictionary> target, TKey valueToCompare, Func<string> getErrorMessage = null)
            where TDictionary : IDictionary<TKey, TValue>
        {
            if (target.Value != null && target.Value.ContainsKey(valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotContain(target, valueToCompare));
            }

            return target;
        }
    }
}
