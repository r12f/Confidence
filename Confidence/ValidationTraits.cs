// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Confidence
{
    /// <summary>
    /// Validation traits.
    /// </summary>
    public class ValidationTraits
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationTraits"/> class.
        /// </summary>
        /// <param name="genericFailureExceptionType">Exception type used when validation failed.</param>
        /// <param name="objectNullExceptionType">Exception type used when object is null.</param>
        /// <param name="outOfRangeExceptionType">Exception type used when object is out of range.</param>
        public ValidationTraits(Type genericFailureExceptionType, Type objectNullExceptionType, Type outOfRangeExceptionType)
        {
            this.GenericFailureExceptionType = genericFailureExceptionType;
            this.ObjectNullExceptionType = objectNullExceptionType;
            this.OutOfRangeExceptionType = outOfRangeExceptionType;
        }

        /// <summary>
        /// Exception type used when validation failed.
        /// </summary>
        public Type GenericFailureExceptionType { get; }

        /// <summary>
        /// Exception type used when obejct is null.
        /// </summary>
        public Type ObjectNullExceptionType { get; }

        /// <summary>
        /// Exception type used when object is out of range.
        /// </summary>
        public Type OutOfRangeExceptionType { get; }
    }
}