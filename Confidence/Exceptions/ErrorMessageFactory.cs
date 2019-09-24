// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Globalization;

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
        public static string ShouldBeNull<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not null.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNull".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeNull<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be null.");
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
        public static string ShouldBeTrueOnCustomAssertion<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "Custom assertion on {0} failed.");
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
        public static string ShouldBeTrue<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not true.");
        }

        /// <summary>
        /// Create error message for "ShouldBeTrue".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeTrue<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be true.");
        }

        /// <summary>
        /// Create error message for "ShouldBeFalse".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeFalse<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not false.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeFalse".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeFalse<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be false.");
        }

        /// <summary>
        /// Create error message for "ShouldBeEqualTo".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeEqualTo<T>(in ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} is not equal to {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeEqualTo".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeEqualTo<T>(in ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} should not be equal to {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSame".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeSame<T>(in ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} is not same object as {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeSame".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeSame<T>(in ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} should not be same object as {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeLessThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeLessThan<T>(in ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} is greater or equal than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeLessOrEqualThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeLessOrEqualThan<T>(in ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} is greater than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeGreaterThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeGreaterThan<T>(in ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} is less or equal than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeGreaterThan".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeGreaterOrEqualThan<T>(in ValidateTarget<T> target, object valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} is less than {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeInRange<T>(in ValidateTarget<T> target, object minValue, object maxValue)
        {
            return CreateErrorMessage(in target, minValue, maxValue, "{0} is not in the range of {1} to {2}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeInRange".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeInRange<T>(in ValidateTarget<T> target, object minValue, object maxValue)
        {
            return CreateErrorMessage(in target, minValue, maxValue, "{0} should not be in the range of {1} to {2}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeNaN".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeNaN<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not NaN.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNaN".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeNaN<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be NaN.");
        }

        /// <summary>
        /// Create error message for "ShouldBeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeInfinity<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeInfinity<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldBePositiveInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBePositiveInfinity<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not positive infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBePositiveInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBePositiveInfinity<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be positive infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldBeNegativeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeNegativeInfinity<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not negative infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeNegativeInfinity".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeNegativeInfinity<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be negative infinity.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveFlag".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveFlag<T>(in ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} doesn't has flag {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotHaveFlag".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveFlag<T>(in ValidateTarget<T> target, T valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} should not have flag {1} set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeEmpty".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeEmpty<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not empty.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeEmpty".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeEmpty<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be empty.");
        }

        /// <summary>
        /// Create error message for "ShouldBeWhiteSpace".
        /// </summary>
        public static string ShouldBeWhiteSpace(in ValidateTarget<string> target)
        {
            return CreateErrorMessage(in target, "{0} is not whitespace.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeWhiteSpace".
        /// </summary>
        public static string ShouldNotBeWhiteSpace(in ValidateTarget<string> target)
        {
            return CreateErrorMessage(in target, "{0} should not be whitespace.");
        }

        /// <summary>
        /// Create error message for "ShouldStartsWith".
        /// </summary>
        public static string ShouldStartWith(in ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} doesn't start with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotStartsWith".
        /// </summary>
        public static string ShouldNotStartWith(in ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} should not start with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldEndsWith".
        /// </summary>
        public static string ShouldEndWith(in ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} doesn't end with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotEndsWith".
        /// </summary>
        public static string ShouldNotEndWith(in ValidateTarget<string> target, string valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} should not end with {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveCount".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveCount<T>(in ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "The number of items in {0} doesn't match {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotHaveCount".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotHaveCount<T>(in ValidateTarget<T> target, int valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "The number of items in {0} should not be {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldContain".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        public static string ShouldContain<T, TItem>(in ValidateTarget<T> target, TItem valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} doesn't contain {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldNotContain".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <typeparam name="TItem">Child item type.</typeparam>
        public static string ShouldNotContain<T, TItem>(in ValidateTarget<T> target, TItem valueToCompare)
        {
            return CreateErrorMessage(in target, valueToCompare, "{0} should not contain {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeIn".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeIn<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not in specified collection.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeIn".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeIn<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be in specified collection.");
        }

        /// <summary>
        /// Create error message for "ShouldHaveAny".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldHaveAny<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "No chlid item in collection {0} passed the predicate.");
        }

        /// <summary>
        /// Create error message for "ShouldAllBe".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldAllBe<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "Not all chlid items in collection {0} passed the predicate.");
        }

        /// <summary>
        /// Create error message for "ShouldBeType".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeType<T>(in ValidateTarget<T> target, Type valueToCompare)
        {
            if (valueToCompare == null)
            {
                throw new ArgumentNullException(nameof(valueToCompare));
            }

            return CreateErrorMessage(in target, valueToCompare.FullName, "{0} is not an object of type {1}.");
        }

        /// <summary>
        /// Create error message for "ShouldBeProperSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeProperSubsetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not a proper subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeProperSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeProperSubsetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be a proper subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeSubsetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not a subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeSubsetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeSubsetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be a subset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeProperSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeProperSupersetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not a proper superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotBeProperSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeProperSupersetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be a proper superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldBeSupersetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} is not a superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeSupersetOf".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotBeSupersetOf<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not be a superset of the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldOverlap".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldOverlap<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} does not overlap with the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldNotOverlap".
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        public static string ShouldNotOverlap<T>(in ValidateTarget<T> target)
        {
            return CreateErrorMessage(in target, "{0} should not overlap with the specified set.");
        }

        /// <summary>
        /// Create error message for "ShouldBeUnreachable".
        /// </summary>
        public static string ShouldBeUnreachable()
        {
            return "Unreachable code executed.";
        }

        private static string CreateErrorMessage<T>(in ValidateTarget<T> target, string errorMessageFormat)
        {
            return string.Format(CultureInfo.InvariantCulture, errorMessageFormat, target.Name);
        }

        private static string CreateErrorMessage<TValue, TValueToCompare>(in ValidateTarget<TValue> target, TValueToCompare expectedValue, string errorMessageFormat)
        {
            return string.Format(CultureInfo.InvariantCulture, errorMessageFormat, target.Name, expectedValue);
        }

        private static string CreateErrorMessage<TValue, TValueToCompare1, TValueToCompare2>(in ValidateTarget<TValue> target, TValueToCompare1 expectedValue1, TValueToCompare2 expectedValue2, string errorMessageFormat)
        {
            return string.Format(CultureInfo.InvariantCulture, errorMessageFormat, target.Name, expectedValue1, expectedValue2);
        }
    }
}
