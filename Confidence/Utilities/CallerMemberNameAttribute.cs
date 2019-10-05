// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET35 || NET40

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Mock the CallerMemberNameAttribute in .NET framework 3.5 and 4.0.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerMemberNameAttribute : Attribute
    {
    }
}

#endif
