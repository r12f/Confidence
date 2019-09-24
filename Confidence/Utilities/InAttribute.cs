// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETSTANDARD1_0

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Mock the InAttribute in netstandard 1.0.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class InAttribute : Attribute
    {
    }
}

#endif
