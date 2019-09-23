using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class DoubleValidationTests
    {
        [Fact]
        public void DoubleSpecialValuesCanBeValidated()
        {
            Requires.Argument(double.NaN, "test").IsNaN();

            Requires.Argument(double.PositiveInfinity, "test").IsInfinity();
            Requires<InvalidOperationException>.Argument(double.PositiveInfinity, "test").IsInfinity();
            Requires.Argument(double.PositiveInfinity, "test").IsPositiveInfinity();
            Requires<InvalidOperationException>.Argument(double.PositiveInfinity, "test").IsPositiveInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(double.PositiveInfinity, "test").NotInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(double.PositiveInfinity, "test").NotInfinity());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(double.PositiveInfinity, "test").NotPositiveInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(double.PositiveInfinity, "test").NotPositiveInfinity());

            Requires.Argument(double.NegativeInfinity, "test").IsInfinity();
            Requires<InvalidOperationException>.Argument(double.NegativeInfinity, "test").IsInfinity();
            Requires.Argument(double.NegativeInfinity, "test").IsNegativeInfinity();
            Requires<InvalidOperationException>.Argument(double.NegativeInfinity, "test").IsNegativeInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(double.NegativeInfinity, "test").NotInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(double.NegativeInfinity, "test").NotInfinity());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(double.NegativeInfinity, "test").NotNegativeInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(double.NegativeInfinity, "test").NotNegativeInfinity());
        }

        [Fact]
        public void NullableDoubleNullCanBeValidated()
        {
            double? testValue = null;
            double allowedError = 0.01f;

            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).Equal(0, allowedError));
            Requires.Argument(testValue, nameof(testValue)).NotEqual(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsLessThan(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsGreaterThan(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(0, allowedError);

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsNaN());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsInfinity());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsPositiveInfinity());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsNegativeInfinity());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void DoubleIsNotNaNCanBeValidated(double v)
        {
            Requires.Argument(v, nameof(v)).NotNaN();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotNaN();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsNaN());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsNaN());

            double? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotNaN();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotNaN();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsNaN());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsNaN());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(double.NaN)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void DoubleIsNotInfinityCanBeValidated(double v)
        {
            Requires.Argument(v, nameof(v)).NotInfinity();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsInfinity());

            double? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotInfinity();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsInfinity());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void DoubleIsNotPositiveInfinityCanBeValidated(double v)
        {
            Requires.Argument(v, nameof(v)).NotPositiveInfinity();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotPositiveInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsPositiveInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsPositiveInfinity());

            double? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotPositiveInfinity();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotPositiveInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsPositiveInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsPositiveInfinity());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void DoubleIsNotNegativeInfinityCanBeValidated(double v)
        {
            Requires.Argument(v, nameof(v)).NotNegativeInfinity();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotNegativeInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsNegativeInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsNegativeInfinity());

            double? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotNegativeInfinity();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotNegativeInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsNegativeInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsNegativeInfinity());
        }

        [Fact]
        public void DoubleComparisonCanBeValidated()
        {
            double objectToTest = 1.0;
            double objectSmaller = 0.99;
            double objectLarger = 1.01;
            double goodAllowedError = 0.001;
            double badAllowedError = 0.1;
            double defaultValue = 0;

            // Equal
            Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectSmaller, badAllowedError);
            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).Equal(objectLarger, badAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectSmaller, goodAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).Equal(objectLarger, goodAllowedError));

            // NotEqual
            Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectSmaller, goodAllowedError);
            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectSmaller, badAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectLarger, badAllowedError));

            // IsLessThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectToTest, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectToTest, badAllowedError));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger, badAllowedError));

            // IsLessOrEqualThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller, goodAllowedError));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectToTest, badAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller, goodAllowedError));

            // IsGreaterThan
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectToTest, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectToTest, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger, goodAllowedError));

            // IsGreaterOrEqualThan
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectToTest, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger, goodAllowedError));

            // InRange
            Requires.Argument(objectToTest, nameof(objectToTest)).InRange(objectToTest, objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).InRange(objectSmaller, objectLarger, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).InRange(objectSmaller, objectLarger, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(objectToTest)).InRange(objectToTest, objectLarger, goodAllowedError));
            Requires.Argument(objectSmaller, nameof(objectToTest)).InRange(objectToTest, objectLarger, badAllowedError);

            // NotInRange
            Requires.Argument(objectToTest, nameof(objectToTest)).NotInRange(objectLarger, objectLarger, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).NotInRange(objectSmaller, objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(objectToTest)).NotInRange(objectToTest, objectLarger, badAllowedError));

            // IsDefault
            Requires.Argument(defaultValue, nameof(defaultValue)).IsDefault(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsDefault(goodAllowedError));

            // NotDefault
            Requires.Argument(objectToTest, nameof(objectToTest)).NotDefault(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).NotDefault(goodAllowedError));
        }

        [Fact]
        public void NullableDoubleComparisonCanBeValidated()
        {
            double objectValue = 1.0f;
            double? nullableObjectToTest = objectValue;
            double objectSmaller = 0.99f;
            double objectLarger = 1.01f;
            double goodAllowedError = 0.001f;
            double badAllowedError = 0.1f;
            double defaultValue = 0f;

            // Equal
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).Equal(objectSmaller, badAllowedError);
            Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).Equal(objectLarger, badAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).Equal(objectSmaller, goodAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).Equal(objectLarger, goodAllowedError));

            // NotEqual
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotEqual(objectSmaller, goodAllowedError);
            Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotEqual(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotEqual(objectSmaller, badAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotEqual(objectLarger, badAllowedError));

            // IsLessThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectSmaller, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectValue, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectValue, badAllowedError));
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessThan(objectLarger, badAllowedError));

            // IsLessOrEqualThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectSmaller, goodAllowedError));
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectValue, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectValue, badAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsLessOrEqualThan(objectSmaller, goodAllowedError));

            // IsGreaterThan
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectValue, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectValue, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectLarger, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterThan(objectLarger, goodAllowedError));

            // IsGreaterOrEqualThan
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectValue, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectValue, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsGreaterOrEqualThan(objectLarger, goodAllowedError));

            // InRange
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).InRange(objectValue, objectValue, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).InRange(objectSmaller, objectLarger, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).InRange(objectSmaller, objectLarger, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(nullableObjectToTest)).InRange(objectValue, objectLarger, goodAllowedError));
            Requires.Argument(objectSmaller, nameof(nullableObjectToTest)).InRange(objectValue, objectLarger, badAllowedError);

            // NotInRange
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotInRange(objectLarger, objectLarger, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotInRange(objectSmaller, objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(nullableObjectToTest)).NotInRange(objectValue, objectLarger, badAllowedError));

            // IsDefault
            Requires.Argument(defaultValue, nameof(defaultValue)).IsDefault(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsDefault(goodAllowedError));

            // NotDefault
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotDefault(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).NotDefault(goodAllowedError));
        }
    }
}
