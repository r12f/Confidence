# Confidence
Write code with Confidence!!!

Confidence is an easy to read and debug fluent argument/condition checker in C# with code contracts syntax supported.

[![NuGet](https://img.shields.io/nuget/v/Confidence.svg?style=flat&color=blue)](https://www.nuget.org/packages/Confidence)
[![Build Status](https://r12f.visualstudio.com/Confidence/_apis/build/status/r12f.Confidence?branchName=master)](https://r12f.visualstudio.com/Confidence/_build/latest?definitionId=1&branchName=master)
[![Code coverage](https://img.shields.io/azure-devops/coverage/r12f/Confidence/1.svg)](https://r12f.visualstudio.com/Confidence/_build/latest?definitionId=1&branchName=master)

.NET versions supported: netstandard >=1.0, .net framework >= 3.5.

**Requirements:** Please [use C# 7.3](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version) for supporting Enum validations and in attribute as readonly ref by adding ```<LangVersion>7.3</LangVersion>``` into your .csproj file.

## Code contracts
Code contracts are better assertions. It is a widely used technique and usually provides 3 variations of assertions to help identifying who is responsible for the failure besides showing what is failing.
- **Requires:** Precondition checks. It describes the requiments that must be met when entering a method. For example: argument should not be null.
- **Ensures:** Postcondition checks. It describes the expectations when exiting a method or after calling an external API.
- **Asserts:** Invariant checks. It describes the expected state in the middle of the things we are trying to do.

Here is a quick example to show how to use code contracts ([full code here](https://github.com/r12f/Confidence/blob/master/Confidence.Samples/Program.cs)):
```
public SomeClass(int foo, string bar)
{
    this.Foo = Requires.Argument(foo, nameof(foo)).NotEqual(0).Value;
    this.Bar = Requires.NotNullArgument(bar, nameof(bar)).NotEmpty().StartsWith("Hello!").Value;

    this.DoSomething(this.Bar.Length);
}

public void DoSomething(int barLength)
{
    Console.WriteLine(barLength);

    // Do something part 1.
    Asserts.Variable(this.Foo, nameof(this.Foo)).NotEqual(0, () => "Foo becomes 0 when we are doing something.");
    // Do something part 2.

    Ensures.IsTrue(this.AreSomeStatesExpected(), () => "Some states are not expected.");
}
```

### Code contracts friendly exceptions
To make code contracts violation more explict in debugging, we added a few exceptions, which all share CodeContractViolationException as base class.
- PreconditionViolationException: Thrown by Requires.Variable and Requires.IsTrue.
- PostconditionViolationException: Thrown by Ensures.Variable and Ensures.IsTrue.
- InvariantViolationException: Thrown by Asserts.Variable and Asserts.IsTrue.

Requires.Argument will throw ArgumentException, ArgumentNullException and ArgumentOutOfRangeException instead of PreconditionViolationException, as it is only used for checking arguments.

## Extensibility
#### Write your own validation
Although many validations are already provided on system types, like object, bool, IComparable (numeric types), float/double, string, nullable, collections, it is never enough. Sometimes, some more customized validations are needed. And here is how to extend Confidence:
```
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
```

#### Write your own assert type
If we need other assert types than Requires, Ensures and Asserts, we can add our own assert types easily. Here is an example:
```
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
```

The full code can be found [here](https://github.com/r12f/Confidence/blob/master/Confidence.Samples/Program.cs).

## Design principles
Here are the design principles of Confidence, and some decisions we make.

### Be compatiable as much as possible
A library working like a if-then-throw check should not limit the platform it runs too much. If something really cannot be supported before certain .NET version, we could use #if to wrap it. And we always has .IsTrue validation as the backup plan.

One hard decision for us to make is validations on enum. Enum as generic is only supported after C# 7.3. It means when this project is created, most people have to add the LangVersion property into their .csproj file to make it work. But since enum is such a important type and so frequently used, using IsTrue with Func validation seems to be even more painful than adding that property. So evetually we still decide to make people upgrade to C# 7.3.

### Readability and debugability comes first
#### Assert one thing at a time
One typical not that good check is string.IsNullOrEmpty. If it fails, are we getting a null or empty string? Depends on which failure we get, it could be caused by totally different issue.

#### Validation target must have a name
A validation without saying what is failing will not be very helpful in debugging.

#### Don't provide validation which is not applicable
When writing code, we are all sort of relying on code completion. So we should try our best to not provide something not really applicable, otherwise, it will just cause more confusion. For example, IsNull check on int.

#### Use code contract keywords instead of just Assert
As it shows above, it makes debugging the issue easier by stating who is responsible for the failure.

#### Use explict code contract exceptions
Many people are using .ToString() to log the exception. As it shows the Exception type name, explict code contract will make debugging the issues even more easier.

### Be easy to use if possible
#### Customizable exception
Sometimes, we need more explict exceptions than the default one, allowing the exception we throw to be customizable is a nice thing to have. So asserts with template argument are also provided as below:
```
Requires<CustomizedException>.Arguments(arg0, nameof(arg0)).NotNull();
Requires<CustomizedException>.Variable(var0, nameof(var0)).NotNull();
Ensures<CustomizedException>.Variable(var1, nameof(var1)).NotNull();
Asserts<CustomizedException>.Variable(var2, nameof(var2)).NotNull();

Requires.IsTrue<CustomizedException>(() => IsSomethingExpected(), () => "Something is not expected.");
Ensures.IsTrue<CustomizedException>(() => IsSomethingExpected(), () => "Something is not expected");
Asserts.IsTrue<CustomizedException>(() => IsSomethingExpected(), () => "Something is not expected");

Requires<CustomizedException>.IsTrue(() => IsSomethingExpected(), () => "Something is not expected");
Ensures<CustomizedException>.IsTrue(() => IsSomethingExpected(), () => "Something is not expected");
Asserts<CustomizedException>.IsTrue(() => IsSomethingExpected(), () => "Something is not expected");
```

#### Easy to make your own assertion types
The same as above, just another nice thing to have, although most of time we don't need it.

### Be performant if possible
#### Cautious about dependencies
It is doable to add more validations in Confidence.dll for many other types, like IPAddress, but it will pull in more depencies when loading Confidence.dll, but not everyone needs it, like System.Net. So instead of putting all validations in this module, we prefer to providing other extension modules for the types which is not loaded by default.

#### Prefer extensions over virtual functions
Using object extensions makes the function call to be determined in compile time (static binding), which will be faster then virtual functions (dynamic binding).

#### Delay error message generation
The error message is only needed when things go wrong. It means most of the time, we don't need it, so it is better to only generate it when we actually need it.

## Contribute
Contributions are very welcome. Just like many other projects:
- Create an issue and discuss.
- Fork the project and change the code.
- Make the pull request and iterate.
- Merge into master branch!

## Release workflow
We are developing in master branch and release from release branches.

All checkins will go to master branch first. Every checkin will [trigger an CI build and produce an alpha nuget package](https://r12f.visualstudio.com/Confidence/_build?definitionId=1&_a=summary). And the package will be published to the [develop feed](https://r12f.visualstudio.com/Confidence/_packaging?_a=feed&feed=Confidence-Develop) automatically after the build is done.

Once we get certain changes ready, we will manually trigger the pipeline to publish the alpha package to nuget.org.

Once we think the package is a good candidate for release, we will create a release branch based on that build and increase the version in master branch. Then build and release the stable package. The release branch will all look like releases/\<package version\>, e.g. releases/1.0.

## License
Code licensed under the [MIT License](https://github.com/r12f/Confidence/blob/master/LICENSE).
