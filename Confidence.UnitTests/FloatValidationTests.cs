using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class FloatValidationTests
    {
        [Fact]
        public void FloatSpecialValuesCanBeValidated()
        {
            Requires.Argument(float.NaN, "test").IsNaN();

            Requires.Argument(float.PositiveInfinity, "test").IsInfinity();
            Requires<InvalidOperationException>.Argument(float.PositiveInfinity, "test").IsInfinity();
            Requires.Argument(float.PositiveInfinity, "test").IsPositiveInfinity();
            Requires<InvalidOperationException>.Argument(float.PositiveInfinity, "test").IsPositiveInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(float.PositiveInfinity, "test").NotInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(float.PositiveInfinity, "test").NotInfinity());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(float.PositiveInfinity, "test").NotPositiveInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(float.PositiveInfinity, "test").NotPositiveInfinity());

            Requires.Argument(float.NegativeInfinity, "test").IsInfinity();
            Requires<InvalidOperationException>.Argument(float.NegativeInfinity, "test").IsInfinity();
            Requires.Argument(float.NegativeInfinity, "test").IsNegativeInfinity();
            Requires<InvalidOperationException>.Argument(float.NegativeInfinity, "test").IsNegativeInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(float.NegativeInfinity, "test").NotInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(float.NegativeInfinity, "test").NotInfinity());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(float.NegativeInfinity, "test").NotNegativeInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(float.NegativeInfinity, "test").NotNegativeInfinity());
        }

        [Fact]
        public void NullableFloatNullCanBeValidated()
        {
            float? testValue = null;
            float allowedError = 0.01f;

            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).Equal(0, allowedError));
            Requires.Argument(testValue, nameof(testValue)).NotEqual(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsLessThan(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsLessOrEqualThan(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsGreaterThan(0, allowedError);
            Requires.Argument(testValue, nameof(testValue)).IsGreaterOrEqualThan(0, allowedError);

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsNaN());
            Requires.Argument(testValue, nameof(testValue)).NotNaN();

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsInfinity());
            Requires.Argument(testValue, nameof(testValue)).NotInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsPositiveInfinity());
            Requires.Argument(testValue, nameof(testValue)).NotPositiveInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).IsNegativeInfinity());
            Requires.Argument(testValue, nameof(testValue)).NotNegativeInfinity();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        public void FloatIsNotNaNCanBeValidated(float v)
        {
            Requires.Argument(v, nameof(v)).NotNaN();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotNaN();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsNaN());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsNaN());

            float? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotNaN();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotNaN();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsNaN());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsNaN());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(float.NaN)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        public void FloatIsNotInfinityCanBeValidated(float v)
        {
            Requires.Argument(v, nameof(v)).NotInfinity();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsInfinity());

            float? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotInfinity();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsInfinity());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(float.NaN)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        public void FloatIsNotPositiveInfinityCanBeValidated(float v)
        {
            Requires.Argument(v, nameof(v)).NotPositiveInfinity();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotPositiveInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsPositiveInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsPositiveInfinity());

            float? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotPositiveInfinity();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotPositiveInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsPositiveInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsPositiveInfinity());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(float.NaN)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        public void FloatIsNotNegativeInfinityCanBeValidated(float v)
        {
            Requires.Argument(v, nameof(v)).NotNegativeInfinity();
            Requires<InvalidOperationException>.Argument(v, nameof(v)).NotNegativeInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsNegativeInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(v, nameof(v)).IsNegativeInfinity());

            float? nullableValue = v;
            Requires.Argument(nullableValue, nameof(nullableValue)).NotNegativeInfinity();
            Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).NotNegativeInfinity();
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(nullableValue, nameof(nullableValue)).IsNegativeInfinity());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nullableValue, nameof(nullableValue)).IsNegativeInfinity());
        }

        [Fact]
        public void FloatComparisonCanBeValidated()
        {
            float objectToTest = 1.0f;
            float objectSmaller = 0.99f;
            float objectLarger = 1.01f;
            float goodAllowedError = 0.001f;
            float badAllowedError = 0.1f;
            float defaultValue = 0f;
            float positiveValue = 1.0f;
            float negativeValue = -1.0f;

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

            // IsInRange
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectToTest, objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectSmaller, objectLarger, goodAllowedError);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectSmaller, objectLarger, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(objectToTest)).IsInRange(objectToTest, objectLarger, goodAllowedError));
            Requires.Argument(objectSmaller, nameof(objectToTest)).IsInRange(objectToTest, objectLarger, badAllowedError);

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

            // IsZero
            Requires.Argument(defaultValue, nameof(defaultValue)).IsZero(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsZero(goodAllowedError));

            // NotZero
            Requires.Argument(objectToTest, nameof(objectToTest)).NotZero(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).NotZero(goodAllowedError));

            // IsPositive
            Requires.Argument(positiveValue, nameof(positiveValue)).IsPositive(goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).IsPositive(goodAllowedError));

            // IsNegative
            Requires.Argument(negativeValue, nameof(negativeValue)).IsNegative(goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).IsNegative(goodAllowedError));
        }

        [Fact]
        public void NullableFloatComparisonCanBeValidated()
        {
            float objectValue = 1.0f;
            float? nullableObjectToTest = objectValue;
            float objectSmaller = 0.99f;
            float objectLarger = 1.01f;
            float goodAllowedError = 0.001f;
            float badAllowedError = 0.1f;
            float defaultValue = 0f;

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

            // IsInRange
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsInRange(objectValue, objectValue, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsInRange(objectSmaller, objectLarger, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsInRange(objectSmaller, objectLarger, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(nullableObjectToTest)).IsInRange(objectValue, objectLarger, goodAllowedError));
            Requires.Argument(objectSmaller, nameof(nullableObjectToTest)).IsInRange(objectValue, objectLarger, badAllowedError);

            // NotInRange
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotInRange(objectLarger, objectLarger, goodAllowedError);
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotInRange(objectSmaller, objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(nullableObjectToTest)).NotInRange(objectValue, objectLarger, badAllowedError));

            // IsDefault
            Requires.Argument(defaultValue, nameof(defaultValue)).IsDefault(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsDefault());

            // NotDefault
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotDefault();
            Assert.Throws<ArgumentException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).NotDefault(goodAllowedError));

            // IsZero
            Requires.Argument(defaultValue, nameof(defaultValue)).IsZero(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).IsZero(goodAllowedError));

            // NotZero
            Requires.Argument(nullableObjectToTest, nameof(nullableObjectToTest)).NotZero(goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).NotZero(goodAllowedError));
        }
    }
}
