// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating ICollection and IConnection{T}.
    /// </summary>
    public static class CollectionValidateTargetExtensions
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
        public static ref readonly ValidateTarget<TCollection> IsEmpty<TCollection>(in this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.InvokeGetCount(target.Value) != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEmpty(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TCollection> IsEmptyByEnumeration<TCollection>(in this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, 1) != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeEmpty(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TCollection> NotEmpty<TCollection>(in this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.InvokeGetCount(target.Value) == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TCollection> NotEmptyByEnumeration<TCollection>(in this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, 1) == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target has expected number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TCollection> Count<TCollection>(in this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.InvokeGetCount(target.Value) != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCount(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target has expected number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TCollection> CountByEnumeration<TCollection>(in this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCount(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't have specific number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TCollection> NotCount<TCollection>(in this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.InvokeGetCount(target.Value) == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveCount(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target doesn't have specific number of child items.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Size)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TCollection> NotCountByEnumeration<TCollection>(in this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveCount(in target, valueToCompare));
            }

            return ref target;
        }

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
        public static ref readonly ValidateTarget<TCollection> Contains<TCollection, TItem>(in this ValidateTarget<TCollection> target, TItem valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (target.Value == null || !TypedCollectionProxy<TCollection, TItem>.Contains(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldContain(in target, valueToCompare));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TCollection> NotContains<TCollection, TItem>(in this ValidateTarget<TCollection> target, TItem valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (target.Value != null && TypedCollectionProxy<TCollection, TItem>.Contains(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotContain(in target, valueToCompare));
            }

            return ref target;
        }

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
        public static ref readonly ValidateTarget<TItem> In<TItem, TCollection>(in this ValidateTarget<TItem> target, TCollection valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (valueToCompare == null || !TypedCollectionProxy<TCollection, TItem>.Contains(valueToCompare, target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeIn(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TItem> NotIn<TItem, TCollection>(in this ValidateTarget<TItem> target, TCollection valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (valueToCompare != null && TypedCollectionProxy<TCollection, TItem>.Contains(valueToCompare, target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeIn(in target));
            }

            return ref target;
        }

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
        public static ref readonly ValidateTarget<TCollection> Any<TCollection, TItem>(in this ValidateTarget<TCollection> target, Func<TItem, bool> predicate, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveAny(in target));
            }

            return ref target;
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
        public static ref readonly ValidateTarget<TCollection> UntypedAny<TCollection>(in this ValidateTarget<TCollection> target, Func<object, bool> predicate, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveAny(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if all child items of this target item will pass with predicate.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="predicate">Predicate for testing child items.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TCollection> All<TCollection, TItem>(in this ValidateTarget<TCollection> target, Func<TItem, bool> predicate, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            bool passedPredicate = true;
            if (target.Value != null)
            {
                foreach (var item in target.Value)
                {
                    if (!predicate.Invoke(item))
                    {
                        passedPredicate = false;
                        break;
                    }
                }
            }

            if (!passedPredicate)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldAllBe(in target));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if all child items of this target item will pass with predicate.
        /// </summary>
        /// <typeparam name="TCollection">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="predicate">Predicate for testing child items.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Collection, ValidationMethodTypes.Children)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TCollection> UntypedAll<TCollection>(in this ValidateTarget<TCollection> target, Func<object, bool> predicate, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            bool passedPredicate = true;
            if (target.Value != null)
            {
                foreach (var item in target.Value)
                {
                    if (!predicate.Invoke(item))
                    {
                        passedPredicate = false;
                        break;
                    }
                }
            }

            if (!passedPredicate)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldAllBe(in target));
            }

            return ref target;
        }

        private static class CollectionProxy<T>
            where T : IEnumerable
        {
            static CollectionProxy()
            {
                GetCount = ExpressionBuilder.CreatePropertyGetter<T, int>("Count");

                if (GetCount == null)
                {
                    GetCount = ExpressionBuilder.CreatePropertyGetter<T, int>("Length");
                }
            }

            private static Func<T, int> GetCount { get; }

            public static int InvokeGetCount(T collection)
            {
                if (GetCount == null)
                {
                    string errorMessage = string.Format(CultureInfo.InvariantCulture, "{0} doesn't have Count or Length property. Please implement either one of them to use this validation.", typeof(T).FullName);
                    throw new InvalidOperationException(errorMessage);
                }

                return GetCount.Invoke(collection);
            }

            public static int GetCountByEnumeration(T collection, int maxEnumerationSteps)
            {
                int count = 0;
                var enumerator = collection.GetEnumerator();
                while (count < maxEnumerationSteps && enumerator.MoveNext())
                {
                    ++count;
                }

                return count;
            }
        }

        private static class TypedCollectionProxy<T, TItem>
            where T : IEnumerable<TItem>
        {
            static TypedCollectionProxy()
            {
                Contains = ExpressionBuilder.CreateMethodWithOneArgsInvoker<T, TItem, bool>("Contains");

                if (Contains == null)
                {
                    Contains = ContainsByEnumeration;
                }
            }

            public static Func<T, TItem, bool> Contains { get; }

            private static bool ContainsByEnumeration(T collection, TItem valueToCompare)
            {
                var comparer = EqualityComparer<TItem>.Default;
                foreach (var item in collection)
                {
                    if (comparer.Equals(item, valueToCompare))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
