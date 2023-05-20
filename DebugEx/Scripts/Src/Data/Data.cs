using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wanna.DebugEx
{
    public static partial class ObjectParser
    {
        public readonly struct Data<T> : IParsable
        {
            readonly T m_obj;

            public Data(T obj)
            {
                this.m_obj = obj;
            }

            public string Parse() => $"{ParseToken(m_obj)}";
        }

        public readonly struct Data<T1, T2> : IParsable
        {
            readonly T1 m_obj1;
            readonly T2 m_obj2;

            public Data(T1 obj1, T2 obj2)
            {
                this.m_obj1 = obj1;
                this.m_obj2 = obj2;
            }

            public string Parse()
            {
                return $"{{{JsonHandler.InsertTab($"\n\"key\": {ParseToken(m_obj1)},\n\"value\": {ParseToken(m_obj2)}", 1)}\n}}";
            }
        }

        public static ParsableTree ToParsableTree<T>(this IEnumerable<T> enumerable)
        {
            return new ParsableTree(enumerable.Select(elm => new Data<T>(elm) as IParsable), typeof(T));
        }

        public static ParsableTree ToParsableTree<T1, T2>(this IEnumerable<KeyValuePair<T1, T2>> enumerable)
        {
            return new ParsableTree(enumerable.Select(elm => new Data<T1, T2>(elm.Key, elm.Value) as IParsable),
                typeof(T1),
                typeof(T2));
        }
    }
}