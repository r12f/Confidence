// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        public static ref readonly ValidateTarget<TSet> IsProperSubsetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsProperSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeProperSubsetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> NotProperSubsetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsProperSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeProperSubsetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> IsSubsetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSubsetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> NotSubsetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsSubsetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSubsetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> IsProperSupersetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsProperSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeProperSupersetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> NotProperSupersetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsProperSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeProperSupersetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> IsSupersetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.IsSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSupersetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> NotSupersetOf<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.IsSupersetOf(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeSupersetOf(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> Overlaps<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (!target.Value.Overlaps(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldOverlap(in target));
                }
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TSet> NotOverlaps<TSet, TItem>(in this ValidateTarget<TSet> target, IEnumerable<TItem> valueToCompare, Func<string> getErrorMessage = null)
            where TSet : ISet<TItem>
        {
            if (target.Value != null)
            {
                if (target.Value.Overlaps(valueToCompare))
                {
                    ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotOverlap(in target));
                }
            }

            return ref target;
        }
#endif
    }
}
