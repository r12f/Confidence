// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Confidence
{
    /// <summary>
    /// Validation method attributes.
    /// </summary>
    public class ValidationMethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationMethodAttribute"/> class.
        /// </summary>
        /// <param name="targetType">Validation target type.</param>
        /// <param name="validationType">Validation type.</param>
        public ValidationMethodAttribute(string targetType, string validationType)
        {
            this.TargetType = targetType;
            this.ValidationType = validationType;
        }

        /// <summary>
        /// Validation target type.
        /// </summary>
        public string TargetType { get; }

        /// <summary>
        /// Validation type.
        /// </summary>
        public string ValidationType { get; }
    }
}
