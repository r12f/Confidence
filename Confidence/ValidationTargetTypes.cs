// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence
{
    /// <summary>
    /// Validation method types.
    /// </summary>
    public static class ValidationTargetTypes
    {
        /// <summary>
        /// No validation target.
        /// </summary>
        public const string None = nameof(None);

        /// <summary>
        /// Object.
        /// </summary>
        public const string Object = nameof(Object);

        /// <summary>
        /// Nullable object.
        /// </summary>
        public const string NullableObject = nameof(NullableObject);

        /// <summary>
        /// Class object.
        /// </summary>
        public const string ClassObject = nameof(ClassObject);

        /// <summary>
        /// Boolean.
        /// </summary>
        public const string Boolean = nameof(Boolean);

        /// <summary>
        /// Float.
        /// </summary>
        public const string Float = nameof(Float);

        /// <summary>
        /// Double.
        /// </summary>
        public const string Double = nameof(Double);

        /// <summary>
        /// String.
        /// </summary>
        public const string String = nameof(String);

        /// <summary>
        /// IComparable.
        /// </summary>
        public const string IComparable = nameof(IComparable);

        /// <summary>
        /// Collection.
        /// </summary>
        public const string Collection = nameof(Collection);

        /// <summary>
        /// Dictionary.
        /// </summary>
        public const string Dictionary = nameof(Dictionary);
    }
}
