// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;

namespace Confidence
{
    /// <summary>
    /// Validate target.
    /// </summary>
    /// <typeparam name="T">Validate target type.</typeparam>
    [DebuggerDisplay("Name = {Name}, Value = {Value}")]
    public class ValidateTarget<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateTarget{T}"/> class.
        /// </summary>
        /// <param name="targetName">target name.</param>
        /// <param name="targetValue">target value.</param>
        /// <param name="validationTraits">Validation trais, like exception type should be used.</param>
        public ValidateTarget(string targetName, T targetValue, ValidationTraits validationTraits)
        {
            this.Value = targetValue;
            this.Name = targetName;
            this.Traits = validationTraits;
        }

        /// <summary>
        /// target name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// target value.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Validation traits.
        /// </summary>
        public ValidationTraits Traits { get; }
    }
}
