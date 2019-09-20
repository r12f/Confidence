using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class BoolValidationTests
    {
        [Fact]
        public void BoolCanBeValidated()
        {
            bool testValue = false;
            Requires.Argument(testValue, nameof(testValue)).IsFalse();
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsFalse();
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).IsTrue());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsTrue());

            testValue = true;
            Requires.Argument(testValue, nameof(testValue)).IsTrue();
            Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsTrue();
            Assert.Throws<ArgumentException>(() => Requires.Argument(testValue, nameof(testValue)).IsFalse());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testValue, nameof(testValue)).IsFalse());
        }
    }
}
