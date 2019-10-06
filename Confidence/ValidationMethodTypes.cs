// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence
{
    /// <summary>
    /// Validation method types.
    /// </summary>
    public static class ValidationMethodTypes
    {
        /// <summary>
        /// Validate a custom assertion.
        /// </summary>
        public const string Custom = nameof(Custom);

        /// <summary>
        /// Validate comparing to another value.
        /// </summary>
        public const string Comparison = nameof(Comparison);

        /// <summary>
        /// Validate size.
        /// </summary>
        public const string Size = nameof(Size);

        /// <summary>
        /// Validate child items.
        /// </summary>
        public const string Children = nameof(Children);

        /// <summary>
        /// Validate type of the target.
        /// </summary>
        public const string Type = nameof(Type);
    }
}