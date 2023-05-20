using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Wanna.DebugEx {
    internal static class DebugExInitializer {
#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#else
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#endif
        static void LoadProfile() {
            DebugEx.debugExProfile = Resources.Load<DebugExProfile>("DebugExProfile");
            Debug.Assert(DebugEx.debugExProfile != null, "DebugExProfile was not found! \nPlease create a profile in the Resources folder.");
        }
    }
}