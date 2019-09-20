// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Globalization;

namespace Confidence
{
    /// <summary>
    /// Assertion tester.
    /// </summary>
    internal static class ExceptionFactory
    {
        /// <summary>
        /// Throw exception with specified exception type and error message.
        /// </summary>
        /// <typeparam name="T">Exception type.</typeparam>
        /// <param name="errorMessage">Error message.</param>
        public static void ThrowException<T>(string errorMessage)
            where T : Exception
        {
            ExceptionFactory.ThrowException(typeof(T), errorMessage);
        }

        /// <summary>
        /// Throw exception with specified exception type and error message.
        /// </summary>
        /// <param name="exceptionType">Exception type.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void ThrowException(Type exceptionType, string errorMessage)
        {
            Exception exception = null;

            try
            {
                exception = Activator.CreateInstance(exceptionType, errorMessage) as Exception;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(errorMessage, ex);
            }

            if (exception == null)
            {
                string failedMessage = string.Format(CultureInfo.InvariantCulture, "Cannot create exception: {0}.", exceptionType.FullName);
                throw new InvalidOperationException(failedMessage);
            }

            throw exception;
        }
    }
}
