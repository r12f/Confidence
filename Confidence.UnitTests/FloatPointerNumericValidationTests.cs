using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class FloatPointerNumericValidationTests
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
        }

        [Fact]
        public void FloatComparisonCanBeValidated()
        {
            float objectToTest = 1.0f;
            float objectSmaller = 0.99f;
            float objectLarger = 1.01f;
            float goodAllowedError = 0.001f;
            float badAllowedError = 0.1f;
            string objectName = "test";

            Requires.Argument(objectToTest, objectName).NotEqual(objectSmaller, goodAllowedError);
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).NotEqual(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, objectName).Equal(objectSmaller, goodAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).Equal(objectLarger, goodAllowedError));

            Requires.Argument(objectToTest, objectName).Equal(objectSmaller, badAllowedError);
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).Equal(objectLarger, badAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, objectName).NotEqual(objectSmaller, badAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).NotEqual(objectLarger, badAllowedError));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectSmaller, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectToTest, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectToTest, badAllowedError));
            Requires.Argument(objectToTest, objectName).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessThan(objectLarger, badAllowedError));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller, goodAllowedError));
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectToTest, badAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller, goodAllowedError));

            Requires.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectToTest, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectToTest, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectLarger, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterThan(objectLarger, goodAllowedError));

            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectToTest, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger, goodAllowedError));
        }

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
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(v, nameof(v)).IsPositiveInfinity());
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
        }

        [Fact]
        public void DoubleComparisonCanBeValidated()
        {
            double objectToTest = 1.0;
            double objectSmaller = 0.99;
            double objectLarger = 1.01;
            double goodAllowedError = 0.001;
            double badAllowedError = 0.1;
            string objectName = "test";

            Requires.Argument(objectToTest, objectName).NotEqual(objectSmaller, goodAllowedError);
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).NotEqual(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, objectName).Equal(objectSmaller, goodAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).Equal(objectLarger, goodAllowedError));

            Requires.Argument(objectToTest, objectName).Equal(objectSmaller, badAllowedError);
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).Equal(objectLarger, badAllowedError);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, objectName).NotEqual(objectSmaller, badAllowedError));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).NotEqual(objectLarger, badAllowedError));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectSmaller, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectToTest, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectToTest, badAllowedError));
            Requires.Argument(objectToTest, objectName).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessThan(objectLarger, badAllowedError));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller, goodAllowedError));
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectToTest, badAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller, goodAllowedError));

            Requires.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectToTest, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectToTest, badAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectLarger, goodAllowedError));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectLarger, badAllowedError));

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterThan(objectLarger, goodAllowedError));

            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller, badAllowedError);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectToTest, goodAllowedError);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectToTest, badAllowedError);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger, badAllowedError);

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller, goodAllowedError);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger, goodAllowedError));
        }
    }
}
