using System;
using Xunit;

namespace Confidence.UnitTests
{
    public class ObjectValidationTests
    {
        [Fact]
        public void ObjectIsTypeCanBeValidated()
        {
            int testInt = 0;
            Requires.Argument(testInt, nameof(testInt)).IsType(typeof(int));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testInt, nameof(testInt)).IsType(typeof(sbyte)));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testInt, nameof(testInt)).IsType(typeof(short)));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testInt, nameof(testInt)).IsType(typeof(long)));

            DerivedClass derivedClass = new DerivedClass();
            Requires.Argument(derivedClass, nameof(derivedClass)).IsType(typeof(BaseInterface));
            Requires.Argument(derivedClass, nameof(derivedClass)).IsType(typeof(BaseClass));
            Requires.Argument(derivedClass, nameof(derivedClass)).IsType(typeof(DerivedClass));

            BaseClass baseClassFromCast = derivedClass;
            Requires.Argument(baseClassFromCast, nameof(baseClassFromCast)).IsType(typeof(BaseInterface));
            Requires.Argument(baseClassFromCast, nameof(baseClassFromCast)).IsType(typeof(BaseClass));
            Requires.Argument(baseClassFromCast, nameof(baseClassFromCast)).IsType(typeof(DerivedClass));

            BaseInterface baseInterfaceFromCast = derivedClass;
            Requires.Argument(baseInterfaceFromCast, nameof(baseInterfaceFromCast)).IsType(typeof(BaseInterface));
            Requires.Argument(baseInterfaceFromCast, nameof(baseInterfaceFromCast)).IsType(typeof(BaseClass));
            Requires.Argument(baseInterfaceFromCast, nameof(baseInterfaceFromCast)).IsType(typeof(DerivedClass));

            BaseClass baseClass = new BaseClass();
            Requires.Argument(baseClass, nameof(baseClass)).IsType(typeof(BaseInterface));
            Requires.Argument(baseClass, nameof(baseClass)).IsType(typeof(BaseClass));
            Assert.Throws<ArgumentException>(() => Requires.Argument(baseClass, nameof(baseClass)).IsType(typeof(DerivedClass)));
        }

        private interface BaseInterface
        {
        }

        private class BaseClass : BaseInterface
        {
        }

        private class DerivedClass : BaseClass
        {
        }
    }
}
