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
            this.RunNumericDefaultValueValidationTests(objectToTest);
            this.RunNullableNumericValidationTestsAgainstNull(objectToTest);
            this.RunNullableNumericValidationTestsAgainstValue(objectToTest, objectSmaller, objectLarger);
        }

        private void RunNumericValueValidationTests<T>(T objectToTest, T objectSmaller, T objectLarger)
            where T : struct, IComparable<T>
        {
            // Equal
            Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectToTest);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectSmaller));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).Equal(objectSmaller));

            // Not Equal
            Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectSmaller);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectToTest));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectToTest));

            // IsLessThan
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectToTest));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller));

            // IsLessOrEqualThan
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectToTest);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller));

            // IsGreaterThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectToTest));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger));

            // IsGreaterOrEqualThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectToTest);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));

            // IsInRange
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectSmaller, objectLarger);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectToTest, objectToTest);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(objectSmaller)).IsInRange(objectToTest, objectLarger));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectToTest, objectToTest);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectSmaller, nameof(objectSmaller)).IsInRange(objectToTest, objectLarger));
        }

        private void RunNumericDefaultValueValidationTests<T>(T objectToTest)
            where T : struct, IComparable<T>
        {
            T defaultValue = default(T);

            // IsDefault
            Requires.Argument(defaultValue, nameof(defaultValue)).IsDefault();
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsDefault());

            // NotDefault
            Requires.Argument(objectToTest, nameof(objectToTest)).NotDefault();
            Assert.Throws<ArgumentException>(() => Requires.Argument(defaultValue, nameof(defaultValue)).NotDefault());
        }

        private void RunNullableNumericValidationTestsAgainstNull<T>(T objectValue)
            where T : struct, IComparable<T>
        {
            T? objectToTest = null;

            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectValue));
            Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectValue);

            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectValue, objectValue);
        }

        private void RunNullableNumericValidationTestsAgainstValue<T>(T objectValue, T objectSmaller, T objectLarger)
            where T : struct, IComparable<T>
        {
            T? objectToTest = objectValue;

            // Equal
            Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectValue);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).Equal(objectSmaller));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).Equal(objectSmaller));

            // Not Equal
            Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectSmaller);
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectValue));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).NotEqual(objectValue));

            // IsLessThan
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectValue));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessThan(objectSmaller));

            // IsLessOrEqualThan
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(objectSmaller));

            // IsGreaterThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger));
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectValue));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(objectLarger));

            // IsGreaterOrEqualThan
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectValue);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller);

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectSmaller);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(objectLarger));

            // IsInRange
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectSmaller, objectLarger);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectValue, objectValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectSmaller, nameof(objectSmaller)).IsInRange(objectValue, objectLarger));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).IsInRange(objectValue, objectValue);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectSmaller, nameof(objectSmaller)).IsInRange(objectValue, objectLarger));

            // NotInRange
            Requires.Argument(objectToTest, nameof(objectToTest)).NotInRange(objectSmaller, objectSmaller);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).NotInRange(objectSmaller, objectLarger));

            Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).NotInRange(objectLarger, objectLarger);
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, nameof(objectToTest)).NotInRange(objectSmaller, objectLarger));
        }
    }
}
