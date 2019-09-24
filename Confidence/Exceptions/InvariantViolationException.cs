// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence.Exceptions
{
    /// <summary>
    /// Exception for representing an invariant violation failure.
    /// </summary>
    public class InvariantViolationException : CodeContractViolationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantViolationException"/> class.
        /// </summary>
        public InvariantViolationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantViolationException"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public InvariantViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantViolationException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvariantViolationException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
