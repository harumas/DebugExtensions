using System;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;

#else
using UnityEngine;
#endif

public static class DebugUtil
{
    public static MethodInfo GetClearConsoleMethodInfo()
    {
#if UNITY_EDITOR
        Assembly assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        Type type = assembly
#if UNITY_2017_1_OR_NEWER
            .GetType("UnityEditor.LogEntries");
#else
           .GetType( "UnityEditorInternal.LogEntries" );
#endif
        MethodInfo method = type.GetMethod("Clear");

        return method;
#else
        return null;
#endif
    }

    public static string ToJson(object obj)
    {
#if UNITY_EDITOR
        return EditorJsonUtility.ToJson(obj, true);
#else
        return JsonUtility.ToJson(obj, true);
#endif
    }
}