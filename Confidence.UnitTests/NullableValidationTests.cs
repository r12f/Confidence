using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class NullableValidationTests
    {
        [Fact]
        public void NullableHasValueCanBeValidated()
        {
            int? objectToTest = 1;
            string objectName = "test";

            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, objectName).HasNoValue());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).HasNoValue());
            Assert.Throws<ArgumentException>(() => Requires.Argument(objectToTest, objectName).IsNull());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsNull());

            Requires.Argument(objectToTest, objectName).HasValue();
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).HasValue();
            Requires.Argument(objectToTest, objectName).NotNull();
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).NotNull();

            objectToTest = null;
            Requires.Argument(objectToTest, objectName).HasNoValue();
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).HasNoValue();
            Requires.Argument(objectToTest, objectName).IsNull();
            Requires<InvalidOperationException>.Argument(objectToTest, objectName).IsNull();
            Assert.Throws<ArgumentNullException>(() => Requires.Argument(objectToTest, objectName).NotNull());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).NotNull());
            Assert.Throws<ArgumentNullException>(() => Requires.Argument(objectToTest, objectName).HasValue());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(objectToTest, objectName).HasValue());
        }
    }
}
