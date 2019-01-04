using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework
{
    public static class Defaults
    {
        private static readonly MethodInfo DefaultMethod 
            = typeof(Defaults).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(m => m.Name == nameof(Default) && m.IsGenericMethod);

        public static object Default(Type type)
            => DefaultMethod.MakeGenericMethod(type).Invoke(null, null);

        public static T Default<T>()
            => default;
    }
}
