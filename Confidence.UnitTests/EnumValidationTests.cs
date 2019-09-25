using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class EnumValidationTests
    {
        [Fact]
        public void EnumEqualCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value2));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value2));
        }

        [Fact]
        public void NullableEnumEqualCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).Equal(null);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testNullValue, nameof(testNullValue)).Equal(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).Equal(TestEnum.Value1));

            TestEnum? testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value2));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value2));
        }

        [Fact]
        public void EnumNotEqualCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value1;

            Requires.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value1));
        }

        [Fact]
        public void NullableEnumNotEqualCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).NotEqual(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).NotEqual(TestEnum.Value1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testNullValue, nameof(testNullValue)).NotEqual(null));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).NotEqual(null));

            TestEnum? testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value1));
        }

        [Fact]
        public void EnumHasFlagCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value2));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value2));
        }

        [Fact]
        public void NullableEnumHasFlagCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Assert.Throws<ArgumentException>(() => Requires.Argument(testNullValue, nameof(testNullValue)).HasFlag(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).HasFlag(TestEnum.Value1));

            TestEnum? testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value2));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).HasFlag(TestEnum.Value2));
        }

        [Fact]
        public void EnumDoesNotHaveFlagCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value1));
        }

        [Fact]
        public void NullableEnumHasNoFlagCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).DoesNotHaveFlag(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).DoesNotHaveFlag(TestEnum.Value1);

            TestEnum? testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).DoesNotHaveFlag(TestEnum.Value1));
        }

        [Fact]
        public void EnumIsLessThanCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value1));
        }

        [Fact]
        public void NullableEnumIsLessThanCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).IsLessThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).IsLessThan(TestEnum.Value2);

            TestEnum testValue = TestEnum.Value1;
            Requires.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessThan(TestEnum.Value1));
        }

        [Fact]
        public void EnumIsLessOrEqualThanCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value2;
            Requires.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value3);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value1));
        }

        [Fact]
        public void NullableEnumIsLessOrEqualThanCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).IsLessOrEqualThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).IsLessOrEqualThan(TestEnum.Value2);

            TestEnum? testValue = TestEnum.Value2;
            Requires.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value3);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(TestEnum.Value1));
        }

        [Fact]
        public void EnumIsGreaterThanCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value3;
            Requires.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value3));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value3));
        }

        [Fact]
        public void NullableEnumIsGreaterThanCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).IsGreaterThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).IsGreaterThan(TestEnum.Value2);

            TestEnum? testValue = TestEnum.Value3;
            Requires.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value3));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterThan(TestEnum.Value3));
        }

        [Fact]
        public void EnumIsGreaterOrEqualThanCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value2;
            Requires.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value3));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value3));
        }

        [Fact]
        public void NullableEnumIsGreaterOrEqualThanCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).IsGreaterOrEqualThan(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).IsGreaterOrEqualThan(TestEnum.Value2);

            TestEnum? testValue = TestEnum.Value2;
            Requires.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value1);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value3));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(TestEnum.Value3));
        }

        [Fact]
        public void EnumInRangeCanBeValidated()
        {
            TestEnum testValue = TestEnum.Value2;
            Requires.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value1, TestEnum.Value3);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value2, TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value3, TestEnum.Value3));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value3, TestEnum.Value3));
        }

        [Fact]
        public void NullableEnumInRangeCanBeValidated()
        {
            TestEnum? testNullValue = null;
            Requires.Argument(testNullValue, nameof(testNullValue)).InRange(TestEnum.Value1, TestEnum.Value3);
            Requires<InvalidOperationException>.Argument(testNullValue, nameof(testNullValue)).InRange(TestEnum.Value1, TestEnum.Value3);

            TestEnum? testValue = TestEnum.Value2;
            Requires.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value1, TestEnum.Value3);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value2, TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value3, TestEnum.Value3));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).InRange(TestEnum.Value3, TestEnum.Value3));
        }

        private enum TestEnum
        {
            Value1 = 1,
            Value2 = 2,
            Value3 = 4,
        }
    }
}
