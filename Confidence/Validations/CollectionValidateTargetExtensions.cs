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
        public static ValidateTarget<TCollection> IsEmpty<TCollection>(this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TCollection> IsEmptyByEnumeration<TCollection>(this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TCollection> NotEmpty<TCollection>(this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TCollection> NotEmptyByEnumeration<TCollection>(this ValidateTarget<TCollection> target, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, 1) == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeEmpty(target));
            }

            return target;
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
        public static ValidateTarget<TCollection> Count<TCollection>(this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCount(target.Value) != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCount(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TCollection> CountByEnumeration<TCollection>(this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value == null || CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) != valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveCount(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TCollection> NotCount<TCollection>(this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCount(target.Value) == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveCount(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TCollection> NotCountByEnumeration<TCollection>(this ValidateTarget<TCollection> target, int valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable
        {
            if (target.Value != null && CollectionProxy<TCollection>.GetCountByEnumeration(target.Value, valueToCompare + 1) == valueToCompare)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotHaveCount(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TCollection> Contains<TCollection, TItem>(this ValidateTarget<TCollection> target, TItem valueToCompare, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TCollection> NotContains<TCollection, TItem>(this ValidateTarget<TCollection> target, TItem valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (target.Value != null && TypedCollectionProxy<TCollection, TItem>.Contains(target.Value, valueToCompare))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotContain(target, valueToCompare));
            }

            return target;
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
        public static ValidateTarget<TItem> In<TItem, TCollection>(this ValidateTarget<TItem> target, TCollection valueToCompare, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TItem> NotIn<TItem, TCollection>(this ValidateTarget<TItem> target, TCollection valueToCompare, Func<string> getErrorMessage = null)
            where TCollection : IEnumerable<TItem>
        {
            if (valueToCompare != null && TypedCollectionProxy<TCollection, TItem>.Contains(valueToCompare, target.Value))
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeIn(target));
            }

            return target;
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
        public static ValidateTarget<TCollection> Any<TCollection, TItem>(this ValidateTarget<TCollection> target, Func<TItem, bool> predicate, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TCollection> UntypedAny<TCollection>(this ValidateTarget<TCollection> target, Func<object, bool> predicate, Func<string> getErrorMessage = null)
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
        public static ValidateTarget<TCollection> All<TCollection, TItem>(this ValidateTarget<TCollection> target, Func<TItem, bool> predicate, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldAllBe(target));
            }

            return target;
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
        public static ValidateTarget<TCollection> UntypedAll<TCollection>(this ValidateTarget<TCollection> target, Func<object, bool> predicate, Func<string> getErrorMessage = null)
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
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldAllBe(target));
            }

            return target;
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

                if (GetCount == null)
                {
                    string errorMessage = string.Format(CultureInfo.InvariantCulture, "{0} doesn't have Count or Length property. Please implement either one of them to use this validation.", typeof(T).FullName);
                    throw new InvalidOperationException(errorMessage);
                }
            }

            public static Func<T, int> GetCount { get; }

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
