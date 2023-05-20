using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanna.DebugEx
{
    [CreateAssetMenu(menuName = "DebugExSetting")]
    public class DebugExProfile : ScriptableObject
    {
        [Header("Path to save the log file")] public string logSavePath = "DebugEx/Logs";

        [Header("Save log with stackTrace")] public bool saveStackTrace = true;
    }
}