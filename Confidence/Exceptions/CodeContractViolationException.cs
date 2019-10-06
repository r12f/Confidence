// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Confidence.Exceptions
{
    /// <summary>
    /// Exception for representing a code contract violation.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237:Mark ISerializable types with serializable", Justification = "Reviewed.")]
    public class CodeContractViolationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeContractViolationException"/> class.
        /// </summary>
        public CodeContractViolationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeContractViolationException"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public CodeContractViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeContractViolationException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CodeContractViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}