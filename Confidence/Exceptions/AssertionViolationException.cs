// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence.Exceptions
{
    /// <summary>
    /// Exception for representing an assertion failure.
    /// </summary>
    public class AssertionViolationException : CodeContractViolationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionViolationException"/> class.
        /// </summary>
        public AssertionViolationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionViolationException"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public AssertionViolationException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
