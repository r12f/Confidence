using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class BasicNumericValidationTests
    {
        [Fact]
        public void SByteCanBeValidated()
        {
            this.RunNumericValidationTests<sbyte>(1, 0, 2);
        }

        [Fact]
        public void ByteCanBeValidated()
        {
            this.RunNumericValidationTests<byte>(1, 0, 2);
        }

        [Fact]
        public void ShortCanBeValidated()
        {
            this.RunNumericValidationTests<short>(1, 0, 2);
        }

        [Fact]
        public void UShortCanBeValidated()
        {
            this.RunNumericValidationTests<ushort>(1, 0, 2);
        }

        [Fact]
        public void IntCanBeValidated()
        {
            this.RunNumericValidationTests<int>(1, 0, 2);
        }

        [Fact]
        public void UIntCanBeValidated()
        {
            this.RunNumericValidationTests<uint>(1, 0, 2);
        }

        [Fact]
        public void LongCanBeValidated()
        {
            this.RunNumericValidationTests<long>(1, 0, 2);
        }

        [Fact]
        public void ULongCanBeValidated()
        {
            this.RunNumericValidationTests<ulong>(1, 0, 2);
        }

        [Fact]
        public void FloatCanBeValidated()
        {
            this.RunNumericValidationTests<float>(1, 0, 2);
        }

        [Fact]
        public void DoubleCanBeValidated()
        {
            this.RunNumericValidationTests<double>(1, 0, 2);
        }

        private void RunNumericValidationTests<T>(T objectToTest, T objectSmaller, T objectLarger)
            where T : struct, IComparable<T>
        {
            string objectName = "test";

            Requires.Argument(objectToTest, objectName).Equal(objectToTest);

            Requires.Argument(objectToTest, objectName).IsLessThan(objectLarger);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectToTest));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessThan(objectSmaller));

            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger);
            Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectToTest);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessOrEqualThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsLessOrEqualThan(objectSmaller));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectLarger));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterThan(objectToTest));
            Requires.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterThan(objectLarger));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectToTest);
            Requires.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsGreaterOrEqualThan(objectLarger));
        }
    }
}
