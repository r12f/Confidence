﻿using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class StringValidationTests
    {
        [Theory]
        [InlineData(null)]
        public void StringIsNullCanBeValidated(string v)
        {
            Requires.Argument(v, nameof(v)).IsNull();
            Assert.Throws<ArgumentNullException>(() => Requires.Argument(v, nameof(v)).NotNull());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).NotNull());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("test")]
        public void StringIsNotNullCanBeValidated(string v)
        {
            Requires.Argument(v, nameof(v)).NotNull();
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).IsNull());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsNull());
        }

        [Theory]
        [InlineData("")]
        public void StringIsEmptyCanBeValidated(string v)
        {
            Requires.Argument(v, nameof(v)).IsEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).NotEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).NotEmpty());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("test")]
        public void StringIsNotEmptyCanBeValidated(string v)
        {
            Requires.Argument(v, nameof(v)).NotEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).IsEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsEmpty());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void StringIsWhiteSpaceCanBeValidated(string v)
        {
            Requires.Argument(v, nameof(v)).IsWhiteSpace();
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).NotWhiteSpace());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).NotWhiteSpace());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("test")]
        public void StringIsNotWhiteSpaceCanBeValidated(string v)
        {
            Requires.Argument(v, nameof(v)).NotWhiteSpace();
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).IsWhiteSpace());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsWhiteSpace());
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("abc", 3)]
        public void StringLengthCanBeValidated(string v, int expected)
        {
            Requires.Argument(v, nameof(v)).LengthIs(expected);
            Requires.Argument(v, nameof(v)).LengthMin(expected);
            Requires.Argument(v, nameof(v)).LengthMax(expected);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).LengthNot(expected));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).LengthNot(expected));
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 1)]
        [InlineData("abc", 2)]
        public void StringLengthNotCanBeValidated(string v, int expected)
        {
            Requires.Argument(v, nameof(v)).LengthNot(expected);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).LengthIs(expected));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).LengthIs(expected));
        }

        [Theory]
        [InlineData("", -1)]
        [InlineData("abc", 2)]
        public void StringLengthMinCanBeValidated(string v, int expected)
        {
            Requires.Argument(v, nameof(v)).LengthMin(expected);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).LengthMax(expected));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).LengthMax(expected));
        }

        [Theory]
        [InlineData("", 1)]
        [InlineData("abc", 4)]
        public void StringLengthMaxCanBeValidated(string v, int expected)
        {
            Requires.Argument(v, nameof(v)).LengthMax(expected);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).LengthMin(expected));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).LengthMin(expected));
        }

        [Theory]
        [InlineData("", -1, 2)]
        [InlineData("", 0, 0)]
        [InlineData("abc", 2, 4)]
        [InlineData("abc", 3, 3)]
        public void StringLengthIsInRangeCanBeValidated(string v, int min, int max)
        {
            Requires.Argument(v, nameof(v)).LengthIsInRange(min, max);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).LengthNotInRange(min, max));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).LengthNotInRange(min, max));
        }

        [Theory]
        [InlineData("", -1, -2)]
        [InlineData("", 1, 2)]
        [InlineData("abc", 1, 2)]
        [InlineData("abc", 4, 5)]
        public void StringLengthNotInRangeCanBeValidated(string v, int min, int max)
        {
            Requires.Argument(v, nameof(v)).LengthNotInRange(min, max);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).LengthIsInRange(min, max));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).LengthIsInRange(min, max));
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "abc")]
        public void StringEqualCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).Equal(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).NotEqual(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).NotEqual(s));
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", " ")]
        [InlineData(" ", "")]
        [InlineData("abc", "a")]
        public void StringNotEqualCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).NotEqual(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).Equal(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).Equal(s));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "a")]
        [InlineData("abc", "abc")]
        public void StringStartsWithSpecificValueCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).StartsWith(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).DoesNotStartWith(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).DoesNotStartWith(s));
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", " ")]
        [InlineData(" ", "  ")]
        [InlineData("abc", "c")]
        [InlineData("abc", "def")]
        public void StringDoesNotStartWithSpecificValueCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).DoesNotStartWith(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).StartsWith(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).StartsWith(s));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "c")]
        [InlineData("abc", "abc")]
        public void StringEndsWithSpecificValueCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).EndsWith(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).DoesNotEndWith(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).DoesNotEndWith(s));
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", " ")]
        [InlineData(" ", "  ")]
        [InlineData("abc", "a")]
        [InlineData("abc", "def")]
        public void StringDoesNotEndWithSpecificValueCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).DoesNotEndWith(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).EndsWith(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).EndsWith(s));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "a")]
        [InlineData("abc", "b")]
        [InlineData("abc", "c")]
        [InlineData("abc", "ab")]
        [InlineData("abc", "bc")]
        [InlineData("abc", "abc")]
        public void StringContainsSpecificValueCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).Contains(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).DoesNotContain(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).DoesNotContain(s));
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData(null, " ")]
        [InlineData("", " ")]
        [InlineData(" ", "  ")]
        [InlineData("abc", "ac")]
        [InlineData("abc", "d")]
        [InlineData("abc", "abcd")]
        public void StringDoesNotContainSpecificValueCanBeValidated(string v, string s)
        {
            Requires.Argument(v, nameof(v)).DoesNotContain(s);
            Assert.Throws<ArgumentException>(() => Requires.Argument(v, nameof(v)).Contains(s));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).Contains(s));
        }
    }
}