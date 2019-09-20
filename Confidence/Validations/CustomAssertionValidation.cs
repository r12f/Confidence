// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Confidence.Validations
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
        /// <param name="assertion">Custom assertion.</param>
        /// <param name="getErrorMessage">Error message.</param>
        [ValidationMethod(ValidationTargetTypes.None, ValidationMethodTypes.Custom)]
        [DebuggerStepThrough]
        public static void IsTrue<TException>(Func<bool> assertion, Func<string> getErrorMessage = null)
            where TException : Exception
        {
            if (assertion.Invoke())
            {
                return;
            }

            ExceptionFactory.ThrowException(typeof(TException), getErrorMessage != null ? getErrorMessage.Invoke() : ErrorMessageFactory.ShouldBeTrue());
        }
    }
}
