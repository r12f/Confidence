using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class NumberBitwiseValidationTests
    {
        [Fact]
        public void SByteCanBeValidated()
        {
            sbyte testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void ByteCanBeValidated()
        {
            byte testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void ShortCanBeValidated()
        {
            short testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void UShortCanBeValidated()
        {
            ushort testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void IntCanBeValidated()
        {
            int testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void UIntCanBeValidated()
        {
            uint testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void LongCanBeValidated()
        {
            long testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }

        [Fact]
        public void ULongCanBeValidated()
        {
            ulong testObject = 7;
            Requires.Argument(testObject, nameof(testObject)).HasBitsSet(5);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(8);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(5));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).DoesNotHaveBitsSet(9));

            Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(9);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testObject, nameof(testObject)).HasAnyBitsSet(8));
        }
    }
}

