using System;
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
    }
}
