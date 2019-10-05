// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Custom assertion validation.
    /// </summary>
    public static class CustomAssertionValidation
    {
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
            if (isValid)
            {
                return;
            }

            ExceptionFactory.ThrowException(typeof(TException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrueOnCustomAssertion());
        }

        /// <summary>
        /// Throw if the object is disposed.
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
            if (!isDisposed)
            {
                return;
            }

            ExceptionFactory.ThrowException(typeof(TException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldNotBeDisposed(objectName));
        }

        /// <summary>
        /// Throw, because it should be unreachable.
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

        /// <summary>
        /// Throw as the function is not supported.
        /// </summary>
        /// <typeparam name="TException">Exception type.</typeparam>
        /// <param name="functionName">Function name.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void NotSupported<TException>(string functionName, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            if (functionName == null)
            {
                throw new ArgumentNullException(nameof(functionName), "Please specific the function name as CallerMemberName is not supported in your .NET framework version.");
            }

            ExceptionFactory.ThrowException(typeof(TException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeSupported(functionName));
        }
    }
}
