using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class BasicNumericValidationTests
    {
        [Fact]
        public void SByteCanBeValidated()
        {
            this.RunSignedNumericValidationTests<sbyte>(1, 0, 2, 1, -1, 0);
        }

        [Fact]
        public void ByteCanBeValidated()
        {
            this.RunUnsignedNumericValidationTests<byte>(1, 0, 2, 1, 0);
        }

        [Fact]
        public void ShortCanBeValidated()
        {
            this.RunSignedNumericValidationTests<short>(1, 0, 2, 1, -1, 0);
        }

        [Fact]
        public void UShortCanBeValidated()
        {
            this.RunUnsignedNumericValidationTests<ushort>(1, 0, 2, 1, 0);
        }

        [Fact]
        public void IntCanBeValidated()
        {
            this.RunSignedNumericValidationTests<int>(1, 0, 2, 1, -1, 0);
        }

        [Fact]
        public void UIntCanBeValidated()
        {
            this.RunUnsignedNumericValidationTests<uint>(1, 0, 2, 1, 0);
        }

        [Fact]
        public void LongCanBeValidated()
        {
            this.RunSignedNumericValidationTests<long>(1, 0, 2, 1, -1, 0);
        }

        [Fact]
        public void ULongCanBeValidated()
        {
            this.RunUnsignedNumericValidationTests<ulong>(1, 0, 2, 1, 0);
        }

        [Fact]
        public void FloatCanBeValidated()
        {
            this.RunSignedNumericValidationTests<float>(1, 0, 2, 1, -1, 0);
        }

        [Fact]
        public void DoubleCanBeValidated()
        {
            this.RunSignedNumericValidationTests<double>(1, 0, 2, 1, -1, 0);
        }

        [Fact]
        public void NullableNumericWithNullValueCanBeValidated()
        {
            int? objectToTest = null;

            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).Equal(0));
            Requires.Argument(objectToTest, nameof(objectToTest)).NotEqual(0);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessThan(0);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsLessOrEqualThan(0);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterThan(0);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsGreaterOrEqualThan(0);
            Requires.Argument(objectToTest, nameof(objectToTest)).IsDefault();
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).NotDefault());
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsZero());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsPositive());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(objectToTest, nameof(objectToTest)).IsNegative());
        }

        private void RunSignedNumericValidationTests<T>(T objectToTest, T objectSmaller, T objectLarger, T positiveObject, T negativeObject, T zeroObject)
            where T : struct, IComparable<T>
        {
            this.RunNumericValidationTests(objectToTest, objectSmaller, objectLarger);
            this.RunSignedNumericPositiveNegativeTests(positiveObject, negativeObject, zeroObject);
        }

        private void RunUnsignedNumericValidationTests<T>(T objectToTest, T objectSmaller, T objectLarger, T positiveObject, T zeroObject)
            where T : struct, IComparable<T>
        {
            this.RunNumericValidationTests(objectToTest, objectSmaller, objectLarger);
            this.RunUnsignedNumericPositiveNegativeTests(positiveObject, zeroObject);
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

        private void RunSignedNumericPositiveNegativeTests<T>(T positiveObject, T negativeObject, T zeroObject)
            where T : struct, IComparable<T>
        {
            // IsPositive
            Requires.Argument(positiveObject, nameof(positiveObject)).IsPositive();
            Requires<InvalidOperationException>.Argument(positiveObject, nameof(positiveObject)).IsPositive();

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(zeroObject, nameof(zeroObject)).IsPositive());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(negativeObject, nameof(negativeObject)).IsPositive());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(negativeObject, nameof(negativeObject)).IsPositive());

            // IsNegative
            Requires.Argument(negativeObject, nameof(negativeObject)).IsNegative();
            Requires<InvalidOperationException>.Argument(negativeObject, nameof(negativeObject)).IsNegative();

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(zeroObject, nameof(zeroObject)).IsNegative());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(positiveObject, nameof(positiveObject)).IsNegative());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(positiveObject, nameof(positiveObject)).IsNegative());
        }

        private void RunUnsignedNumericPositiveNegativeTests<T>(T positiveObject, T zeroObject)
            where T : struct, IComparable<T>
        {
            // IsPositive
            Requires.Argument(positiveObject, nameof(positiveObject)).IsPositive();
            Requires<InvalidOperationException>.Argument(positiveObject, nameof(positiveObject)).IsPositive();

            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(zeroObject, nameof(zeroObject)).IsPositive());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(zeroObject, nameof(zeroObject)).IsPositive());

            // IsNegative
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(zeroObject, nameof(zeroObject)).IsNegative());
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(positiveObject, nameof(positiveObject)).IsNegative());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(positiveObject, nameof(positiveObject)).IsNegative());
        }
    }
}
