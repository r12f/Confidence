// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Exceptions;

namespace Confidence
{
    /// <summary>
    /// Assert assertion.
    /// Invariant checks. It describes the expected state in the middle of the things we are trying to do.
    /// </summary>
    public static class Asserts
    {
        private static readonly ValidateTargetFactory<InvariantViolationException, InvariantViolationException, InvariantViolationException> VariableValidateTargetFactory =
            new ValidateTargetFactory<InvariantViolationException, InvariantViolationException, InvariantViolationException>();

        /// <summary>
        /// Create validate target for regular variables.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>Validate target.</returns>
        [DebuggerStepThrough]
        public static ValidateTarget<T> Variable<T>(T targetValue, string targetName)
        {
            return VariableValidateTargetFactory.Create(targetValue, targetName);
        }

        /// <summary>
        /// Validate if a custom assertion returns true.
        /// </summary>
        /// <param name="assertion">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue(Func<bool> assertion, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<InvariantViolationException>(assertion, getErrorMessage);
        }

        /// <summary>
        /// Validate if a custom assertion returns true.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="assertion">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue<TException>(Func<bool> assertion, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            CustomAssertionValidation.IsTrue<InvariantViolationException>(assertion, getErrorMessage);
        }

        /// <summary>
        /// Throw InvalidOperationException, because it should be unreachable.
        /// </summary>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void UnreachableCode(Func<string> getErrorMessage = null)
        {
            ExceptionFactory.ThrowException(typeof(InvalidOperationException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeUnreachable());
        }

        /// <summary>
        /// Throw specified exception, because it should be unreachable.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void UnreachableCode<TException>(Func<string> getErrorMessage = null)
            where TException : Exception
        {
            ExceptionFactory.ThrowException(typeof(TException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeUnreachable());
        }
    }

    /// <summary>
    /// Assert assertion.
    /// If this assertion failed, it means something within the current class or module is wrong, and this failure should be handled by the owner of this class or module.
    /// </summary>
    /// <typeparam name="TException">Exception type.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Variations of Asserts.")]
    public static class Asserts<TException>
        where TException : Exception
    {
        private static readonly ValidateTargetFactory<TException, TException, TException> VariableValidateTargetFactory = new ValidateTargetFactory<TException, TException, TException>();

        /// <summary>
        /// Create validate target for regular variables.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>Validate target.</returns>
        [DebuggerStepThrough]
        public static ValidateTarget<T> Variable<T>(T targetValue, string targetName)
        {
            return VariableValidateTargetFactory.Create(targetValue, targetName);
        }

        /// <summary>
        /// Validate if a custom assertion returns true.
        /// </summary>
        /// <param name="assertion">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue(Func<bool> assertion, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<TException>(assertion, getErrorMessage);
        }

        /// <summary>
        /// Throw, because it should be unreachable.
        /// </summary>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void UnreachableCode(Func<string> getErrorMessage = null)
        {
            ExceptionFactory.ThrowException(typeof(TException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeUnreachable());
        }
    }
}
