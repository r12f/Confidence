// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Confidence
{
    /// <summary>
    /// Validation method types.
    /// </summary>
    public static class ValidationTargetTypes
    {
#pragma warning disable CA1720 // Identifier contains type name

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
        /// Integer.
        /// </summary>
        public const string Integer = nameof(Integer);

        /// <summary>
        /// Float.
        /// </summary>
        public const string Float = nameof(Float);

        /// <summary>
        /// Double.
        /// </summary>
        public const string Double = nameof(Double);

        /// <summary>
        /// Enum.
        /// </summary>
        public const string Enum = nameof(Enum);

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
        /// Set.
        /// </summary>
        public const string Set = nameof(Set);

        /// <summary>
        /// Dictionary.
        /// </summary>
        public const string Dictionary = nameof(Dictionary);

#pragma warning restore CA1720 // Identifier contains type name
    }
}