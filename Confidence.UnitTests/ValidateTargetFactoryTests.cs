using System;
using FluentAssertions;
using Xunit;

namespace Confidence.UnitTests
{
    public class ValidateTargetFactoryTests
    {
        [Fact]
        public void FactoryCanCreateValidationTargetWithCorrectTraits()
        {
            ValidateTargetFactory<ArgumentException, ArgumentNullException, ArgumentOutOfRangeException> factory = new ValidateTargetFactory<ArgumentException, ArgumentNullException, ArgumentOutOfRangeException>();

            var target = factory.Create(1, "test");
            target.Should().NotBeNull();
            target.Name.Should().Be("test");
            target.Value.Should().Be(1);
            target.Traits.GenericFailureExceptionType.Should().Be(typeof(ArgumentException));
            target.Traits.ObjectNullExceptionType.Should().Be(typeof(ArgumentNullException));
            target.Traits.OutOfRangeExceptionType.Should().Be(typeof(ArgumentOutOfRangeException));

            ValidateTargetFactory<InvalidOperationException, InvalidOperationException, IndexOutOfRangeException> factory2 = new ValidateTargetFactory<InvalidOperationException, InvalidOperationException, IndexOutOfRangeException>();

            var target2 = factory2.Create(2, "test2");
            target2.Should().NotBeNull();
            target2.Name.Should().Be("test2");
            target2.Value.Should().Be(2);
            target2.Traits.GenericFailureExceptionType.Should().Be(typeof(InvalidOperationException));
            target2.Traits.ObjectNullExceptionType.Should().Be(typeof(InvalidOperationException));
            target2.Traits.OutOfRangeExceptionType.Should().Be(typeof(IndexOutOfRangeException));
        }
    }
}
