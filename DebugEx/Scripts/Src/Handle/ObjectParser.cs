using UnityEngine;

namespace Wanna.DebugEx
{
    public static partial class ObjectParser
    {
        public static string ParseToken<T>(T elem)
        {
            bool nearlyPrimitive = IsNearlyPrimitive<T>();
            return nearlyPrimitive ? $"\"{elem}\"" : DebugUtil.ToJson(elem);
        }

        public static string ParseColor(Color message)
        {
            return $"#{ColorUtility.ToHtmlStringRGBA(message).Color(message)}  Color({message.r}, {message.g}, {message.b}, {message.a})";
        }


        static bool IsNearlyPrimitive<T>()
        {
            return typeof(T).IsPrimitive ||
                   typeof(T).IsEnum ||
                   typeof(T) == typeof(string) ||
                   typeof(T) == typeof(decimal);
        }
    }
}