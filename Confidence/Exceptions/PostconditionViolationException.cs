// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence.Exceptions
{
    /// <summary>
    /// Exception for representing an postcondition violation failure.
    /// </summary>
    public class PostconditionViolationException : CodeContractViolationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostconditionViolationException"/> class.
        /// </summary>
        public PostconditionViolationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostconditionViolationException"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public PostconditionViolationException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
