// Copyright (c) r12f. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq.Expressions;

#if NETSTANDARD1_0
#endif
using System.Reflection;

namespace Confidence.Utilities
{
    /// <summary>
    /// Expression builder.
    /// </summary>
    public static class ExpressionBuilder
    {
        /// <summary>
        /// Creating function for getting property from an object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <typeparam name="TProperty">Property type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Function for getting the property.</returns>
        public static Func<T, TProperty> CreatePropertyGetter<T, TProperty>(string propertyName)
        {
            var type = typeof(T);

#if NETSTANDARD1_0
            var propertyGetter = type.GetTypeInfo().GetDeclaredProperty(propertyName)?.GetMethod;
#else
            var propertyGetter = type.GetProperty(propertyName)?.GetGetMethod();
#endif

            if (propertyGetter == null)
            {
                return null;
            }

            if (propertyGetter.IsStatic != false || propertyGetter.ReturnType != typeof(TProperty))
            {
                return null;
            }

            var thisPointer = Expression.Parameter(typeof(T), "thisPointer");
            var propertyGetterCall = Expression.Call(thisPointer, propertyGetter);
            var lambda = Expression.Lambda<Func<T, TProperty>>(propertyGetterCall, thisPointer);
            return lambda.Compile();
        }

        /// <summary>
        /// Creating function for calling function with 1 argument on an object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <typeparam name="TArg0">Argument 0 type.</typeparam>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="methodName">Function name.</param>
        /// <returns>Function for getting the property.</returns>
        public static Func<T, TArg0, TReturn> CreateMethodWithOneArgsInvoker<T, TArg0, TReturn>(string methodName)
        {
            var type = typeof(T);

#if NETSTANDARD1_0
            var method = type.GetTypeInfo().GetDeclaredMethod(methodName);
#else
            var method = type.GetMethod(methodName);
#endif

            if (method == null)
            {
                return null;
            }

            if (method.IsStatic != false || method.ReturnType != typeof(TReturn))
            {
                return null;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return null;
            }

            if (parameters[0].ParameterType != typeof(TArg0))
            {
                return null;
            }

            var thisPointer = Expression.Parameter(typeof(T), "obj");
            var argument0 = Expression.Parameter(typeof(TArg0), "arg0");
            var methodCall = Expression.Call(thisPointer, method, new[] { argument0 });
            var lambda = Expression.Lambda<Func<T, TArg0, TReturn>>(methodCall, new[] { thisPointer, argument0 });
            return lambda.Compile();
        }
    }
}
