using System;
using System.Diagnostics;

namespace Confidence.Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass(1, "Hello! World!");
            MyAsserts.Variable(someClass, nameof(someClass)).NotNull().FooNotZero();
            Console.WriteLine("Yay!");
            Console.ReadLine();
        }
    }

    public class SomeClass
    {
        public SomeClass(int foo, string bar)
        {
            this.Foo = Requires.Argument(foo, nameof(foo)).NotEqual(0).Value;
            this.Bar = Requires<CustomizedException>.Argument(bar, nameof(bar)).NotNull().NotEmpty().StartsWith("Hello!").Value;

            this.DoSomething();
        }

        public int Foo { get; set; }

        public string Bar { get; set; }

        public void DoSomething()
        {
            // Do something part 1.
            Asserts.Variable(this.Foo, nameof(this.Foo)).NotEqual(0, () => "Foo becomes 0 when we are doing something.");
            // Do something part 2.

            Ensures.IsTrue(this.AreSomeStatesExpected(), () => "Some states are not expected.");
        }

        private bool AreSomeStatesExpected()
        {
            // Some checks here.
            return true;
        }
    }

    public static class MyAsserts
    {
        private static readonly ValidateTargetFactory<CustomizedException, CustomizedNullException, CustomizedOutOfRangeException> VariableValidateTargetFactory =
            new ValidateTargetFactory<CustomizedException, CustomizedNullException, CustomizedOutOfRangeException>();

        [DebuggerStepThrough]
        public static ValidateTarget<T> Variable<T>(T targetValue, string targetName)
        {
            return VariableValidateTargetFactory.Create(targetValue, targetName);
        }

        [DebuggerStepThrough]
        public static void IsTrue(bool isValid, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<CustomizedException>(isValid, getErrorMessage);
        }
    }

    public static class SomeClassValidateTargetExtensions
    {
        [DebuggerStepThrough]
        public static ValidateTarget<SomeClass> FooNotZero(this ValidateTarget<SomeClass> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.Foo == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : "Foo cannot be zero.");
            }

            return target;
        }
    }

    internal class CustomizedException : Exception
    {
    }

    internal class CustomizedNullException : Exception
    {
    }

    internal class CustomizedOutOfRangeException : Exception
    {
    }
}
