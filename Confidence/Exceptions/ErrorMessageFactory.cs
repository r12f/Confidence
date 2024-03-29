﻿// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Globalization;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Error message factory.
    /// </summary>
    public static class ErrorMessageFactory
    {
        /// <summary>
        /// Create error message for "ShouldBeNull".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeNull<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not null.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNull".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeNull<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be null.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNull".
        /// </summary>
        public static string ShouldNotBeNull(string targetName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} should not be null.", targetName);
        }

        /// <summary>
        /// Create error message for "ShouldBeTrueOnCustomAssertion".
        /// </summary>
        public static string ShouldBeTrueOnCustomAssertion()
        {
            return "Custom assertion failed.";
        }

        /// <summary>
        /// Create error message for "ShouldBeTrueOnCustomAssertion".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeTrueOnCustomAssertion<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "Custom assertion on {0} failed.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeDisposed".
        /// </summary>
        public static string ShouldNotBeDisposed(string objectName)
        {
            return string.Format(CultureInfo.InvariantCulture, "Object {0} has already been disposed.", objectName);
        }

        /// <summary>
        /// Create error message for "ShouldBeTrue".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeTrue<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not true.");
        }

        /// <summary>
        /// Create error message for "ShouldBeTrue".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeTrue<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be true.");
        }

        /// <summary>
        /// Create error message for "ShouldBeFalse".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeFalse<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not false.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeFalse".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeFalse<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be false.");
        }

        /// <summary>
        /// Create error message for "ShouldBeEqualTo".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeEqualTo<T>([ValidatedNotNull] ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} is not equal to {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeEqualTo".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeEqualTo<T>([ValidatedNotNull] ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not be equal to {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSame".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeSame<T>([ValidatedNotNull] ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} is not same object as {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeSame".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeSame<T>([ValidatedNotNull] ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not be same object as {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeLessThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeLessThan<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} is greater or equal than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeLessOrEqualThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeLessOrEqualThan<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} is greater than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeGreaterThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeGreaterThan<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} is less or equal than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeGreaterThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeGreaterOrEqualThan<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} is less than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeInRange<T>([ValidatedNotNull] ValidateTarget<T> target, object minValue, object maxValue)
        {
            return CreateErrorMessage(target, minValue, maxValue, "{0} is not in the range of {1} to {2}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeInRange<T>([ValidatedNotNull] ValidateTarget<T> target, object minValue, object maxValue)
        {
            return CreateErrorMessage(target, minValue, maxValue, "{0} should not be in the range of {1} to {2}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveBitSet".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveBitsSet<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} doesn't has bits {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotHaveBitsSet".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveBitsSet<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not have bits {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveAnyBitSet".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveAnyBitsSet<T>([ValidatedNotNull] ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} doesn't has any of bits {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeNaN".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeNaN<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not NaN.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNaN".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeNaN<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be NaN.");
        }

        /// <summary>
        /// Create error message for "ShouldBeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeInfinity<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeInfinity<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldBePositiveInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBePositiveInfinity<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not positive infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBePositiveInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBePositiveInfinity<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be positive infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldBeNegativeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeNegativeInfinity<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not negative infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNegativeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeNegativeInfinity<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be negative infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveFlag".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveFlag<T>([ValidatedNotNull] ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} doesn't has flag {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotHaveFlag".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveFlag<T>([ValidatedNotNull] ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not have flag {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeEmpty".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeEmpty<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not empty.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeEmpty".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeEmpty<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be empty.");
        }

        /// <summary>
        /// Create error message for "ShouldBeWhiteSpace".
        /// </summary>
        public static string ShouldBeWhiteSpace([ValidatedNotNull] ValidateTarget<string> target)
        {
            return CreateErrorMessage(target, "{0} is not whitespace.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeWhiteSpace".
        /// </summary>
        public static string ShouldNotBeWhiteSpace([ValidatedNotNull] ValidateTarget<string> target)
        {
            return CreateErrorMessage(target, "{0} should not be whitespace.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveLength".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveLength<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The length of {0} doesn't match {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotHaveLength".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveLength<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The length of {0} should not be {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveMinLength".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveMinLength<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The length of {0} is shorter than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveMaxLength".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveMaxLength<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The length of {0} is longer than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveLengthInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveLengthInRange<T>([ValidatedNotNull] ValidateTarget<T> target, int min, int max)
        {
            return CreateErrorMessage(target, min, max, "The length of {0} is not in the range of [{1}, {2}].");
        }

        /// <summary>
        /// Create error message for "ShouldHaveLengthInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveLengthInRange<T>([ValidatedNotNull] ValidateTarget<T> target, int min, int max)
        {
            return CreateErrorMessage(target, min, max, "The length of {0} should not be in the range of [{1}, {2}].");
        }

        /// <summary>
        /// Create error message for "ShouldStartsWith".
        /// </summary>
        public static string ShouldStartWith([ValidatedNotNull] ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} doesn't start with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotStartsWith".
        /// </summary>
        public static string ShouldNotStartWith([ValidatedNotNull] ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not start with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldEndsWith".
        /// </summary>
        public static string ShouldEndWith([ValidatedNotNull] ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} doesn't end with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotEndsWith".
        /// </summary>
        public static string ShouldNotEndWith([ValidatedNotNull] ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not end with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveCount".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveCount<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The number of items in {0} doesn't match {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotHaveCount".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveCount<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The number of items in {0} should not be {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveMinCount".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveMinCount<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The number of items in {0} should be larger or equal than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveMaxCount".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveMaxCount<T>([ValidatedNotNull] ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "The number of items in {0} should be smaller or equal than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveCountInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveCountInRange<T>([ValidatedNotNull] ValidateTarget<T> target, int min, int max)
        {
            return CreateErrorMessage(target, min, max, "The number of items in {0} is not in the range of [{1}, {2}].");
        }

        /// <summary>
        /// Create error message for "ShouldHaveCountInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveCountInRange<T>([ValidatedNotNull] ValidateTarget<T> target, int min, int max)
        {
            return CreateErrorMessage(target, min, max, "The number of items in {0} should not be in the range of [{1}, {2}].");
        }

        /// <summary>
        /// Create error message for "ShouldContain".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        public static string ShouldContain<T, TItem>([ValidatedNotNull] ValidateTarget<T> target, TItem valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} doesn't contain {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotContain".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        public static string ShouldNotContain<T, TItem>([ValidatedNotNull] ValidateTarget<T> target, TItem valueToCompare)
        {
            return CreateErrorMessage(target, valueToCompare, "{0} should not contain {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeIn".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeIn<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not in specified collection.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeIn".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeIn<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be in specified collection.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveAny".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveAny<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "No chlid item in collection {0} passed the predicate.");
        }

        /// <summary>
        /// Create error message for "ShouldAllBe".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldAllBe<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "Not all chlid items in collection {0} passed the predicate.");
        }

        /// <summary>
        /// Create error message for "ShouldBeType".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeType<T>([ValidatedNotNull] ValidateTarget<T> target, Type valueToCompare)
        {
            if (valueToCompare == null)
            {
                throw new ArgumentNullException(nameof(valueToCompare));
            }

            return CreateErrorMessage(target, valueToCompare.FullName, "{0} is not an object of type {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeProperSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeProperSubsetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not a proper subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeProperSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeProperSubsetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be a proper subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeSubsetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not a subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeSubsetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be a subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeProperSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeProperSupersetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not a proper superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeProperSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeProperSupersetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be a proper superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeSupersetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} is not a superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeSupersetOf<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not be a superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldOverlap".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldOverlap<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} does not overlap with the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotOverlap".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotOverlap<T>([ValidatedNotNull] ValidateTarget<T> target)
        {
            return CreateErrorMessage(target, "{0} should not overlap with the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeUnreachable".
        /// </summary>
        public static string ShouldBeUnreachable()
        {
            return "Unreachable code executed.";
        }

        /// <summary>
        /// Create error message for "ShouldBeSupported".
        /// </summary>
        public static string ShouldBeSupported(string functionName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} is not supported yet.", functionName);
        }

        private static string CreateErrorMessage<T>([ValidatedNotNull] ValidateTarget<T> target, string errorMessageFormat)
        {
            return string.Format(CultureInfo.InvariantCulture, errorMessageFormat, target.Name);
        }

        private static string CreateErrorMessage<TValue, TValueToCompare>([ValidatedNotNull] ValidateTarget<TValue> target, TValueToCompare expectedValue, string errorMessageFormat)
        {
            return string.Format(CultureInfo.InvariantCulture, errorMessageFormat, target.Name, expectedValue);
        }

        private static string CreateErrorMessage<TValue, TValueToCompare1, TValueToCompare2>([ValidatedNotNull] ValidateTarget<TValue> target, TValueToCompare1 expectedValue1, TValueToCompare2 expectedValue2, string errorMessageFormat)
        {
            return string.Format(CultureInfo.InvariantCulture, errorMessageFormat, target.Name, expectedValue1, expectedValue2);
        }
    }
}