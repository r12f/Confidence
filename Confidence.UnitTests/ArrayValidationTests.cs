using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class ArrayValidationTests
    {
        [Fact]
        public void ArrayIsEmptyCanBeValidated()
        {
            int[] emptyArray = new int[0];
            Requires.Argument(emptyArray, nameof(emptyArray)).IsEmpty();
            Requires<InvalidOperationException>.Argument(emptyArray, nameof(emptyArray)).IsEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyArray, nameof(emptyArray)).NotEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyArray, nameof(emptyArray)).NotEmpty());

            int[] nonEmptyArray = new int[1];
            Requires.Argument(nonEmptyArray, nameof(nonEmptyArray)).NotEmpty();
            Requires<InvalidOperationException>.Argument(nonEmptyArray, nameof(nonEmptyArray)).NotEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyArray, nameof(nonEmptyArray)).IsEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyArray, nameof(nonEmptyArray)).IsEmpty());
        }

        [Fact]
        public void ArrayCountCanBeValidated()
        {
            int[] emptyArray = new int[0];
            Requires.Argument(emptyArray, nameof(emptyArray)).Count(0);
            Requires<InvalidOperationException>.Argument(emptyArray, nameof(emptyArray)).Count(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyArray, nameof(emptyArray)).Count(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyArray, nameof(emptyArray)).Count(1));

            int[] nonEmptyArray = new int[1];
            Requires.Argument(nonEmptyArray, nameof(nonEmptyArray)).Count(1);
            Requires<InvalidOperationException>.Argument(nonEmptyArray, nameof(nonEmptyArray)).Count(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyArray, nameof(nonEmptyArray)).Count(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyArray, nameof(nonEmptyArray)).Count(0));
        }

        [Fact]
        public void ArrayContainsSpecificValueCanBeValidated()
        {
            int[] testArray = new int[2] { 1, 2 };
            Requires.Argument(testArray, nameof(testArray)).Contains(1);
            Requires<InvalidOperationException>.Argument(testArray, nameof(testArray)).Contains(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testArray, nameof(testArray)).Contains(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testArray, nameof(testArray)).Contains(0));
        }

        [Fact]
        public void SpecificValueInArrayCanBeValidated()
        {
            int[] testArray = new int[2] { 1, 2 };

            int testValue = 1;
            Requires.Argument(testValue, nameof(testValue)).In(testArray);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).In(testArray);

            testValue = 0;
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).In(testArray));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).In(testArray));
        }
    }
}
