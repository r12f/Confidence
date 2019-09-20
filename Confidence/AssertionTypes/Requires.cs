// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Globalization;
using Confidence.Exceptions;
using Confidence.Validations;

namespace Confidence
{
    /// <summary>
    /// Requires assertion.
    /// If this assertion failed, it means some prerequisites for running next code are not met.
    /// It indicates something before this assertion or outside this function is wrong.
    /// </summary>
    public static class Requires
    {
        private static readonly ValidateTargetFactory<ArgumentException, ArgumentNullException, ArgumentOutOfRangeException> ArgumentValidateTargetFactory =
            new ValidateTargetFactory<ArgumentException, ArgumentNullException, ArgumentOutOfRangeException>();

        private static readonly ValidateTargetFactory<PreconditionViolationException, PreconditionViolationException, PreconditionViolationException> VariableValidateTargetFactory =
            new ValidateTargetFactory<PreconditionViolationException, PreconditionViolationException, PreconditionViolationException>();

        /// <summary>
        /// Create validate target for argument.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>Validate target.</returns>
        [DebuggerStepThrough]
        public static ValidateTarget<T> Argument<T>(T targetValue, string targetName)
        {
            return ArgumentValidateTargetFactory.Create(targetValue, targetName);
        }

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
        /// <param name="argumentName">Argument name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void ArgumentIsTrue(Func<bool> assertion, string argumentName, Func<string> getErrorMessage = null)
        {
            Func<string> finalGetErrorMessage = getErrorMessage;
            if (finalGetErrorMessage == null)
            {
                finalGetErrorMessage = () => string.Format(CultureInfo.InvariantCulture, "Custom assersion on argument {0} failed.", argumentName);
            }

            CustomAssertionValidation.IsTrue<ArgumentException>(assertion, finalGetErrorMessage);
        }

        /// <summary>
        /// Validate if a custom assertion returns true.
        /// </summary>
    /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="assertion">Custom assertion.</param>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void ArgumentIsTrue<TException>(Func<bool> assertion, string argumentName, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            Func<string> finalGetErrorMessage = getErrorMessage;
            if (finalGetErrorMessage == null)
            {
                finalGetErrorMessage = () => string.Format(CultureInfo.InvariantCulture, "Custom assersion on argument {0} failed.", argumentName);
            }

            CustomAssertionValidation.IsTrue<TException>(assertion, finalGetErrorMessage);
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
            CustomAssertionValidation.IsTrue<PreconditionViolationException>(assertion, getErrorMessage);
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
            CustomAssertionValidation.IsTrue<PreconditionViolationException>(assertion, getErrorMessage);
        }
    }

    /// <summary>
    /// Requires assertion with exception template.
    /// If this assertion failed, it means some prerequisites for running next code are not met.
    /// It indicates something before this assertion or outside this function is wrong.
    /// </summary>
    /// <typeparam name="TException">Exception type.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Variations of Requires.")]
    public static class Requires<TException>
        where TException : Exception
    {
        private static readonly ValidateTargetFactory<TException, TException, TException> ArgumentValidateTargetFactory = new ValidateTargetFactory<TException, TException, TException>();
        private static readonly ValidateTargetFactory<TException, TException, TException> VariableValidateTargetFactory = new ValidateTargetFactory<TException, TException, TException>();

        /// <summary>
        /// Create validate target for argument.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>Validate target.</returns>
        [DebuggerStepThrough]
        public static ValidateTarget<T> Argument<T>(T targetValue, string targetName)
        {
            return ArgumentValidateTargetFactory.Create(targetValue, targetName);
        }

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
        /// <param name="argumentName">Argument name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void ArgumentIsTrue(Func<bool> assertion, string argumentName, Func<string> getErrorMessage = null)
        {
            Func<string> finalGetErrorMessage = getErrorMessage;
            if (finalGetErrorMessage == null)
            {
                finalGetErrorMessage = () => string.Format(CultureInfo.InvariantCulture, "Custom assersion on argument {0} failed.", argumentName);
            }

            CustomAssertionValidation.IsTrue<TException>(assertion, finalGetErrorMessage);
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
    }
}
