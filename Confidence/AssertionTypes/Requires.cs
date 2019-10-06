// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Confidence.Exceptions;
using Confidence.Utilities;

namespace Confidence
{
    /// <summary>
    /// Requires assertion.
    /// Precondition checks. It describes the requiments that must be met when entering a method.
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
        /// Create validate target for not null argument. If the argument is null, we will throw ArgumentNullException.
        /// This helps in fixing CA1062:ValidateArgumentsOfPublicMethods, as NotNull check against target cannot be recognized by code analysis.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>Validate target.</returns>
        [DebuggerStepThrough]
        public static ValidateTarget<T> NotNullArgument<T>([ValidatedNotNull] T targetValue, string targetName)
            where T : class
        {
            if (targetValue == null)
            {
                ExceptionFactory.ThrowException(typeof(ArgumentNullException), ErrorMessageFactory.ShouldNotBeNull(targetName));
            }

            return ArgumentValidateTargetFactory.Create(targetValue, targetName);
        }

        /// <summary>
        /// Create validate target for not null argument. If the argument is null, we will throw ArgumentNullException.
        /// This helps in fixing CA1062:ValidateArgumentsOfPublicMethods, as NotNull check against target cannot be recognized by code analysis.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="targetValue">Target value.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>Validate target.</returns>
        [DebuggerStepThrough]
        public static ValidateTarget<T?> NotNullArgument<T>([ValidatedNotNull] T? targetValue, string targetName)
            where T : struct
        {
            if (!targetValue.HasValue)
            {
                ExceptionFactory.ThrowException(typeof(ArgumentNullException), ErrorMessageFactory.ShouldNotBeNull(targetName));
            }

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
        /// <param name="isValid">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue(bool isValid, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<PreconditionViolationException>(isValid, getErrorMessage);
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

#if NET35 || NET40
        /// <summary>
        /// Throw NotSupportedException, because this function is not supported yet.
        /// </summary>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported(string functionName, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.NotSupported<NotSupportedException>(functionName, getErrorMessage);
        }

        /// <summary>
        /// Throw specific exception, because this function is not supported yet.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported<TException>(string functionName, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            CustomAssertionValidation.NotSupported<TException>(functionName, getErrorMessage);
        }
#else
        /// <summary>
        /// Throw NotSupportedException, because this function is not supported yet.
        /// </summary>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported([CallerMemberName] string functionName = null, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.NotSupported<NotSupportedException>(functionName, getErrorMessage);
        }

        /// <summary>
        /// Throw specific exception, because this function is not supported yet.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported<TException>([CallerMemberName] string functionName = null, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            CustomAssertionValidation.NotSupported<TException>(functionName, getErrorMessage);
        }
#endif

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
            CustomAssertionValidation.UnreachableCode<TException>(getErrorMessage);
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

#pragma warning disable CA1000 // Do not declare static members on generic types

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
        /// <param name="isValid">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue(bool isValid, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.IsTrue<TException>(isValid, getErrorMessage);
        }

#if NET35 || NET40
        /// <summary>
        /// Throw specific exception, because this function is not supported yet.
        /// </summary>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported(string functionName, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.NotSupported<TException>(functionName, getErrorMessage);
        }
#else
        /// <summary>
        /// Throw specific exception, because this function is not supported yet.
        /// </summary>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported([CallerMemberName] string functionName = null, Func<string> getErrorMessage = null)
        {
            CustomAssertionValidation.NotSupported<TException>(functionName, getErrorMessage);
        }
#endif

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
