// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating ISet{T}.
    /// </summary>
    public static class SetValidateTargetExtensions
    {
#if !NET35
        /// <summary>
        /// Validate if target is a proper subset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> IsProperSubsetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsProperSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeProperSubsetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not a proper subset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotProperSubsetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsProperSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeProperSubsetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is a subset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> IsSubsetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSubsetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not a subset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotSubsetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSubsetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is a proper superset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> IsProperSupersetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsProperSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeProperSupersetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not a proper superset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotProperSupersetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsProperSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeProperSupersetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is a superset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> IsSupersetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSupersetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target is not a superset of a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotSupersetOf<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSupersetOf(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target overlaps with a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> Overlaps<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.Overlaps(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldOverlap(target));
                }
            }

            return target;
        }

        /// <summary>
        /// Validate if target doesn't overlap with a specific set. If null, this check will be a no-op.
        /// </summary>
        /// <typeparam name="TSet">Target type.</typeparam>
        /// <typeparam name="TItem">Item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Set, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ValidateTarget<TSet> NotOverlaps<TSet, TItem>([ValidatedNotNull] this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.Overlaps(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotOverlap(target));
                }
            }

            return target;
        }
#endif
    }
}
