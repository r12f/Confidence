// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Confidence.Utilities
{
    /// <summary>
    /// ValidatedNotNull attribute for CA1062.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
