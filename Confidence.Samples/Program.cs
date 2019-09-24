// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

#pragma warning disable SA1204 // Static elements should appear before instance elements
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1400 // Access modifier should be declared
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
#pragma warning disable SA1512 // Single-line comments should not be followed by blank line
#pragma warning disable SA1202 // Elements should be ordered by access
#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Confidence.Samples
{
    public class Program
    {
        static void Main()
        {
            SomeClass someClass = new SomeClass(1, "Hello World!");
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

            Requires.NotNullArgument(bar, nameof(bar)).NotEmpty().StartsWith("Hello");
            this.DoSomething(bar.Length);
        }

        public int Foo { get; set; }

        public void DoSomething(int barLength)
        {
            Console.WriteLine(barLength);

            // Do something part 1.
            Asserts.Variable(this.Foo, nameof(this.Foo)).NotEqual(0, () => "Foo becomes 0 when we are doing something.");
            // Do something part 2.

            Ensures.IsTrue(this.AreSomeStatesExpected(), () => "Some states are not expected.");
        }

        private bool AreSomeStatesExpected()
        {
            // Some checks here.
            return this.Foo > 0;
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
        public static ref readonly ValidateTarget<SomeClass> FooNotZero(in this ValidateTarget<SomeClass> target, Func<string> getErrorMessage = null)
        {
            if (target.Value.Foo == 0)
            {
                ExceptionFactory.ThrowException(target.Traits.GenericFailureExceptionType, getErrorMessage != null ? getErrorMessage.Invoke() : "Foo cannot be zero.");
            }

            return ref target;
        }
    }

    public class CustomizedException : Exception
    {
        public CustomizedException()
        {
        }

        public CustomizedException(string message)
            : base(message)
        {
        }

        public CustomizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class CustomizedNullException : Exception
    {
        public CustomizedNullException()
        {
        }

        public CustomizedNullException(string message)
            : base(message)
        {
        }

        public CustomizedNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class CustomizedOutOfRangeException : Exception
    {
        public CustomizedOutOfRangeException()
        {
        }

        public CustomizedOutOfRangeException(string message)
            : base(message)
        {
        }

        public CustomizedOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

#pragma warning restore CA1303 // Do not pass literals as localized parameters
#pragma warning restore SA1202 // Elements should be ordered by access
#pragma warning restore SA1512 // Single-line comments should not be followed by blank line
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning restore SA1402 // File may only contain a single type
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1204 // Static elements should appear before instance elements
