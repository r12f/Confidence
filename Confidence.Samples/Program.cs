using System;

namespace Confidence.Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass(1, "abc");
            Console.WriteLine("Hello World!");
        }
    }

    internal class SomeClass
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

            Ensures.IsTrue(() => this.AreSomeStatesExpected(), () => "Some states are not expected.");
        }

        private bool AreSomeStatesExpected()
        {
            // Some checks here.
            return true;
        }
    }

    internal class CustomizedException : Exception
    {
    }
}
