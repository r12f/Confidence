﻿// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target extensions used for validating IComparable objects.
    /// </summary>
    public static class ComparableValidateTargetExtensions
    {
        /// <summary>
        /// Validate if target is less than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsLessThan<TValue>(in this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) >= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsLessThan<TValue>(in this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) >= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsLessThan<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) >= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsLessThan<TValue>(in this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) >= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsLessOrEqualThan<TValue>(in this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) > 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsLessOrEqualThan<TValue>(in this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsLessOrEqualThan<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) > 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is less or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsLessOrEqualThan<TValue>(in this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeLessOrEqualThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsGreaterThan<TValue>(in this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) <= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsGreaterThan<TValue>(in this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) <= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsGreaterThan<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) <= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsGreaterThan<TValue>(in this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) <= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsGreaterOrEqualThan<TValue>(in this ValidateTarget<TValue> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) < 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsGreaterOrEqualThan<TValue>(in this ValidateTarget<TValue?> target, object valueToCompare, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) < 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> IsGreaterOrEqualThan<TValue>(in this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, valueToCompare) < 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(in target, valueToCompare));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is greater or equal than a specific value. If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> IsGreaterOrEqualThan<TValue>(in this ValidateTarget<TValue?> target, TValue valueToCompare, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, valueToCompare) < 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeGreaterOrEqualThan(in target, valueToCompare));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is within a range (larger or equal than min and less or equal than max).
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> InRange<TValue>(in this ValidateTarget<TValue> target, object minValue, object maxValue, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, minValue) < 0 || comparer.Compare(target.Value, maxValue) > 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(in target, minValue, maxValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is within a range (larger or equal than min and less or equal than max). If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> InRange<TValue>(in this ValidateTarget<TValue?> target, object minValue, object maxValue, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, minValue) < 0 || comparer.Compare(target.Value.Value, maxValue) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(in target, minValue, maxValue));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is within a range (larger or equal than min and less or equal than max).
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> InRange<TValue>(in this ValidateTarget<TValue> target, TValue minValue, TValue maxValue, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, minValue) < 0 || comparer.Compare(target.Value, maxValue) > 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(in target, minValue, maxValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is within a range (larger or equal than min and less or equal than max). If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> InRange<TValue>(in this ValidateTarget<TValue?> target, TValue minValue, TValue maxValue, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, minValue) < 0 || comparer.Compare(target.Value.Value, maxValue) > 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeInRange(in target, minValue, maxValue));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not within a range (less than min and larger than max).
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> NotInRange<TValue>(in this ValidateTarget<TValue> target, object minValue, object maxValue, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : IComparable
        {
            System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, minValue) >= 0 && comparer.Compare(target.Value, maxValue) <= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(in target, minValue, maxValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not within a range (less than min and larger than max). If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> NotInRange<TValue>(in this ValidateTarget<TValue?> target, object minValue, object maxValue, Func<string> getErrorMessage = null, System.Collections.IComparer customComparer = null)
            where TValue : struct, IComparable
        {
            if (target.Value.HasValue)
            {
                System.Collections.IComparer comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, minValue) >= 0 && comparer.Compare(target.Value.Value, maxValue) <= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(in target, minValue, maxValue));
                }
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not within a range (less than min and larger than max).
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue> NotInRange<TValue>(in this ValidateTarget<TValue> target, TValue minValue, TValue maxValue, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : IComparable<TValue>
        {
            IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
            if (comparer.Compare(target.Value, minValue) >= 0 && comparer.Compare(target.Value, maxValue) <= 0)
            {
                ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(in target, minValue, maxValue));
            }

            return ref target;
        }

        /// <summary>
        /// Validate if target is not within a range (less than min and larger than max). If null, this check will be a no-op, as they are not comparable.
        /// </summary>
        /// <typeparam name="TValue">Target type.</typeparam>
        /// <param name="target">Validate target.</param>
        /// <param name="minValue">Min.</param>
        /// <param name="maxValue">Max.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <param name="customComparer">Custom comparer.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.IComparable, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ref readonly ValidateTarget<TValue?> NotInRange<TValue>(in this ValidateTarget<TValue?> target, TValue minValue, TValue maxValue, Func<string> getErrorMessage = null, IComparer<TValue> customComparer = null)
            where TValue : struct, IComparable<TValue>
        {
            if (target.Value.HasValue)
            {
                IComparer<TValue> comparer = customComparer ?? Comparer<TValue>.Default;
                if (comparer.Compare(target.Value.Value, minValue) >= 0 && comparer.Compare(target.Value.Value, maxValue) <= 0)
                {
                    ExceptionFactory.ThrowException(target.Traits.OutOfRangeExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeInRange(in target, minValue, maxValue));
                }
            }

            return ref target;
        }
    }
}