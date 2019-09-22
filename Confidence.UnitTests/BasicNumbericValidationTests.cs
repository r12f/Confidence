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
            this.RunNumericValueValidationTests(objectToTest, objectSmaller, objectLarger);
            this.RunNullableNumericValidationTestsAgainstNull(objectToTest);
            this.RunNullableNumericValidationTestsAgainstValue(objectToTest, objectSmaller, objectLarger);
        }

        private void RunNumericValueValidationTests<T>(T objectToTest, T objectSmaller, T objectLarger)
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

        private void RunNullableNumericValidationTestsAgainstNull<T>(T objectValue)
            where T : struct, IComparable<T>
        {
            T? objectToTest = null;

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectValue));
            Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectValue);

            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectValue);
        }

        private void RunNullableNumericValidationTestsAgainstValue<T>(T objectValue, T objectSmaller, T objectLarger)
            where T : struct, IComparable<T>
        {
            T? objectToTest = objectValue;

            Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectValue));

            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectValue));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller));

            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectValue));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger));

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));
        }
    }
}
