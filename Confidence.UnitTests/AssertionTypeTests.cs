using System;
using FluentAssertions;
using Confidence.Exceptions;
using Xunit;

namespace Confidence.UnitTests
{
    public class AssertionTypeTests
    {
        [Fact]
        public void RequiresArgumentCanCreateValidateTargets()
        {
            var target = Requires.Argument(1, "test");
            target.Should().NotBeNull();
            target.Name.Should().Be("test");
            target.Value.Should().Be(1);
            target.Traits.GenericFailureExceptionType.Should().Be(typeof(ArgumentException));
            target.Traits.ObjectNullExceptionType.Should().Be(typeof(ArgumentNullException));
            target.Traits.OutOfRangeExceptionType.Should().Be(typeof(ArgumentOutOfRangeException));
        }

        [Fact]
        public void RequiresVariableCanCreateValidateTargets()
        {
            var target = Requires.Variable(1, "test");
            target.Should().NotBeNull();
            target.Name.Should().Be("test");
            target.Value.Should().Be(1);
            target.Traits.GenericFailureExceptionType.Should().Be(typeof(PreconditionViolationException));
            target.Traits.ObjectNullExceptionType.Should().Be(typeof(PreconditionViolationException));
            target.Traits.OutOfRangeExceptionType.Should().Be(typeof(PreconditionViolationException));
        }

        [Fact]
        public void RequiresIsTrueCanValidate()
        {
            Requires.IsTrue(() => true);
            Requires.IsTrue<InvalidOperationException>(() => true, () => "Customized error message.");
            Requires<InvalidOperationException>.IsTrue(() => true, () => "Customized error message.");

            Assert.Throws<PreconditionViolationException>(() => Requires.IsTrue(() => false));
            Assert.Throws<InvalidOperationException>(() => Requires.IsTrue<InvalidOperationException>(() => false, () => "Customized error message."));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.IsTrue(() => false, () => "Customized error message."));
        }

        [Fact]
        public void EnsuresVariableCanCreateValidateTargets()
        {
            var target = Ensures.Variable(1, "test");
            target.Should().NotBeNull();
            target.Name.Should().Be("test");
            target.Value.Should().Be(1);
            target.Traits.GenericFailureExceptionType.Should().Be(typeof(PostconditionViolationException));
            target.Traits.ObjectNullExceptionType.Should().Be(typeof(PostconditionViolationException));
            target.Traits.OutOfRangeExceptionType.Should().Be(typeof(PostconditionViolationException));
        }

        [Fact]
        public void EnsuresIsTrueCanValidate()
        {
            Ensures.IsTrue(() => true);
            Ensures.IsTrue<InvalidOperationException>(() => true, () => "Customized error message.");
            Ensures<InvalidOperationException>.IsTrue(() => true, () => "Customized error message.");

            Assert.Throws<PostconditionViolationException>(() => Ensures.IsTrue(() => false));
            Assert.Throws<InvalidOperationException>(() => Ensures.IsTrue<InvalidOperationException>(() => false, () => "Customized error message."));
            Assert.Throws<InvalidOperationException>(() => Ensures<InvalidOperationException>.IsTrue(() => false, () => "Customized error message."));
        }

        [Fact]
        public void AssertsVariableCanCreateValidateTargets()
        {
            var target = Asserts.Variable(1, "test");
            target.Should().NotBeNull();
            target.Name.Should().Be("test");
            target.Value.Should().Be(1);
            target.Traits.GenericFailureExceptionType.Should().Be(typeof(InvariantViolationException));
            target.Traits.ObjectNullExceptionType.Should().Be(typeof(InvariantViolationException));
            target.Traits.OutOfRangeExceptionType.Should().Be(typeof(InvariantViolationException));
        }

        [Fact]
        public void AssertsUnreachableShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => Asserts.UnreachableCode());
            Assert.Throws<InvariantViolationException>(() => Asserts.UnreachableCode<InvariantViolationException>());
            Assert.Throws<InvariantViolationException>(() => Asserts<InvariantViolationException>.UnreachableCode());
        }
    }
}
