// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence.Exceptions
{
    /// <summary>
    /// Exception for representing an precondition violation failure.
    /// </summary>
    public class PreconditionViolationException : CodeContractViolationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionViolationException"/> class.
        /// </summary>
        public PreconditionViolationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionViolationException"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public PreconditionViolationException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
