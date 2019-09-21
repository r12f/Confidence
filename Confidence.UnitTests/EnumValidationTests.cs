using System;
using System.Globalization;
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
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value2));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).Equal(TestEnum.Value2));

            Requires.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value2);
            Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Argument(testValue, nameof(testValue)).NotEqual(TestEnum.Value1));
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

            Requires.Argument(testValue, nameof(testValue)).HasNoFlag(TestEnum.Value2);
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).HasNoFlag(TestEnum.Value2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).HasNoFlag(TestEnum.Value1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).HasNoFlag(TestEnum.Value1));
        }

        private enum TestEnum
        {
            Value1 = 1,
            Value2 = 2,
        }
    }
}
