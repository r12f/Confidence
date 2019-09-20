// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Confidence.Exceptions
{
    /// <summary>
    /// Exception for representing a code contract violation.
    /// </summary>
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
    }
}
