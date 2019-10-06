// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Extensions for validating if a bit is set in a integer number.
    /// </summary>
    public static class IntegerNumberAnyBitsSetValidationExtensions
    {
        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<sbyte> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<sbyte> target, sbyte valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<sbyte>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<byte> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<byte> target, byte valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<byte>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<short> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<short> target, short valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<short>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<ushort> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<ushort> target, ushort valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<ushort>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<int> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<int> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<int>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<uint> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<uint> target, uint valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<uint>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<long> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<long> target, long valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<long>(target, valueToCompare, getErrorMessage);
        }

        /// <summary>
        /// Validate if target has certain bits set.
        /// </summary>
        /// <param name="target">Validate target.</param>
        /// <param name="valueToCompare">Value to compare.</param>
        /// <param name="getErrorMessage">Custom error message.</param>
        /// <returns>The same validate target as passed in.</returns>
        [ValidationMethod(ValidationTargetTypes.Integer, ValidationMethodTypes.Comparison)]
        [DebuggerStepThrough]
        public static ValidateTarget<ulong> HasAnyBitsSet([ValidatedNotNull] this ValidateTarget<ulong> target, ulong valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberAnyBitsSetValidationExtensions.HasAnyBitsSet<ulong>(target, valueToCompare, getErrorMessage);
        }

        private static ValidateTarget<TValue> HasAnyBitsSet<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>, IEquatable<TValue>
        {
            if (IntegerProxy<TValue>.BitwiseAnd(target.Value, valueToCompare).CompareTo(default(TValue)) == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveAnyBitsSet(target, valueToCompare));
            }

            return target;
        }
    }
}