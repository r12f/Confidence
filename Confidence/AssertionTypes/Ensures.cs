// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using Confidence.Exceptions;

namespace Confidence
{
    /// <summary>
    /// Ensures assertion.
    /// Postcondition checks. It describes the expectations when exiting a method or after calling an external API.
    /// </summary>
    public static class Ensures
    {
        private static readonly ValidateTargetFactory<PostconditionViolationException, PostconditionViolationException, PostconditionViolationException> VariableValidateTargetFactory =
            new ValidateTargetFactory<PostconditionViolationException, PostconditionViolationException, PostconditionViolationException>();

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
        /// <param name="isValid">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue(bool isValid, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<PostconditionViolationException>(isValid, getErrorMessage);
        }

        /// <summary>
        /// Validate if a custom assertion returns true.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="isValid">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue<TException>(bool isValid, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            CustomAssertionValidation.IsTrue<TException>(isValid, getErrorMessage);
        }

        /// <summary>
        /// Throw ObjectDisposedException, is the custom assertion fails.
        /// </summary>
        /// <param name="isDisposed">Is disposed value.</param>
        /// <param name="objectName">Object name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotDisposed(bool isDisposed, string objectName, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.NotDisposed<ObjectDisposedException>(isDisposed, objectName, getErrorMessage);
        }

        /// <summary>
        /// Throw ObjectDisposedException, is the custom assertion fails.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="isDisposed">Is disposed value.</param>
        /// <param name="objectName">Object name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotDisposed<TException>(bool isDisposed, string objectName, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            CustomAssertionValidation.NotDisposed<TException>(isDisposed, objectName, getErrorMessage);
        }
    }

    /// <summary>
    /// Ensures assertion with exception template.
    /// If this assertion failed, it means the result of the last operation is not expected.
    /// </summary>
    /// <typeparam name="TException">Exception type.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Variations of Ensures.")]
    public static class Ensures<TException>
        where TException : Exception
    {
        private static readonly ValidateTargetFactory<TException, TException, TException> VariableValidateTargetFactory = new ValidateTargetFactory<TException, TException, TException>();

#pragma warning disable CA1000 // Do not declare static members on generic types
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
        /// <param name="isValid">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue(bool isValid, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<TException>(isValid, getErrorMessage);
        }

        /// <summary>
        /// Throw ObjectDisposedException, is the custom assertion fails.
        /// </summary>
        /// <param name="isDisposed">Is disposed value.</param>
        /// <param name="objectName">Object name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotDisposed(bool isDisposed, string objectName, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.NotDisposed<TException>(isDisposed, objectName, getErrorMessage);
        }

#pragma warning restore CA1000 // Do not declare static members on generic types
    }
}
