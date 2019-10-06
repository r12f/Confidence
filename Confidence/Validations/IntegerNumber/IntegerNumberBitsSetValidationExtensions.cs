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
    public static class IntegerNumberBitsSetValidationExtensions
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
        public static ValidateTarget<sbyte> HasBitsSet([ValidatedNotNull] this ValidateTarget<sbyte> target, sbyte valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<sbyte>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<byte> HasBitsSet([ValidatedNotNull] this ValidateTarget<byte> target, byte valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<byte>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<short> HasBitsSet([ValidatedNotNull] this ValidateTarget<short> target, short valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<short>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<ushort> HasBitsSet([ValidatedNotNull] this ValidateTarget<ushort> target, ushort valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<ushort>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<int> HasBitsSet([ValidatedNotNull] this ValidateTarget<int> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<int>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<uint> HasBitsSet([ValidatedNotNull] this ValidateTarget<uint> target, uint valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<uint>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<long> HasBitsSet([ValidatedNotNull] this ValidateTarget<long> target, long valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<long>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<ulong> HasBitsSet([ValidatedNotNull] this ValidateTarget<ulong> target, ulong valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.HasBitsSet<ulong>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<sbyte> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<sbyte> target, sbyte valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<sbyte>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<byte> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<byte> target, byte valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<byte>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<short> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<short> target, short valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<short>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<ushort> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<ushort> target, ushort valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<ushort>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<int> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<int> target, int valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<int>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<uint> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<uint> target, uint valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<uint>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<long> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<long> target, long valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<long>(target, valueToCompare, getErrorMessage);
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
        public static ValidateTarget<ulong> DoesNotHaveBitsSet([ValidatedNotNull] this ValidateTarget<ulong> target, ulong valueToCompare, Func<string> getErrorMessage = null)
        {
            return IntegerNumberBitsSetValidationExtensions.DoesNotHaveBitsSet<ulong>(target, valueToCompare, getErrorMessage);
        }

        private static ValidateTarget<TValue> HasBitsSet<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>, IEquatable<TValue>
        {
            if (IntegerProxy<TValue>.BitwiseAnd(target.Value, valueToCompare).CompareTo(valueToCompare) != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveBitsSet(target, valueToCompare));
            }

            return target;
        }

        private static ValidateTarget<TValue> DoesNotHaveBitsSet<TValue>([ValidatedNotNull] this ValidateTarget<TValue> target, TValue valueToCompare, Func<string> getErrorMessage = null)
            where TValue : struct, IComparable<TValue>, IEquatable<TValue>
        {
            if (IntegerProxy<TValue>.BitwiseAnd(target.Value, valueToCompare).CompareTo(default(TValue)) != 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldHaveBitsSet(target, valueToCompare));
            }

            return target;
        }
    }
}