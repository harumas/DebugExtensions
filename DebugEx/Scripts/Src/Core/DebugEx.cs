using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;
using System.Text;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Wanna.DebugEx
{
    public static class DebugEx
    {
        /// <summary>
        ///   <para>Reports whether the development console is visible. The development console cannot be made to appear using:</para>
        /// </summary>
        public static bool developerConsoleVisible
        {
            get => Debug.developerConsoleVisible;
            set => Debug.developerConsoleVisible = value;
        }

        /// <summary>
        ///   <para>In the Build Settings dialog there is a check box called "Development Build".</para>
        /// </summary>
        public static bool isDebugBuild
        {
            get => Debug.isDebugBuild;
        }

        /// <summary>
        ///   <para>Get default debug logger.</para>
        /// </summary>
        public static ILogger unityLogger
        {
            get => Debug.unityLogger;
        }

        #region Normal

        static object ConvertEnumerableToObject<T>(IEnumerable<T> message)
        {
            return message != null ? message.ToParsableTree().ToObject() : null;
        }

        static object ConvertEnumerableToObject<T1, T2>(IEnumerable<KeyValuePair<T1, T2>> message)
        {
            return message != null ? message.ToParsableTree().ToObject() : null;
        }


        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log<T>(IEnumerable<T> message)
        {
            Debug.unityLogger.Log(LogType.Log, ConvertEnumerableToObject(message));
        }

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log<T1, T2>(IEnumerable<KeyValuePair<T1, T2>> message)
        {
            Debug.unityLogger.Log(LogType.Log, ConvertEnumerableToObject(message));
        }

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log(string message)
        {
            Debug.unityLogger.Log(LogType.Log, message);
        }


        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log(Color message)
        {
            Debug.unityLogger.Log(LogType.Log, ObjectParser.ParseColor(message));
        }


        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log(object message)
        {
            Debug.unityLogger.Log(LogType.Log, message);
        }

        #endregion

        #region Context

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log<T>(IEnumerable<T> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Log, ConvertEnumerableToObject(message), context);
        }

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Log, ConvertEnumerableToObject(message), context);
        }

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log(string message, Object context)
        {
            Debug.unityLogger.Log(LogType.Log, (object)message, context);
        }

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log(Color message, Object context)
        {
            Debug.unityLogger.Log(LogType.Log, (object)ObjectParser.ParseColor(message), context);
        }


        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Log(object message, Object context)
        {
            Debug.unityLogger.Log(LogType.Log, message, context);
        }

        #endregion

        #region Format

        /// <summary>
        ///   <para>Logs a formatted message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogFormat(string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Log, format, args);
        }


        /// <summary>
        ///   <para>Logs a formatted message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogFormat(Object context, string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Log, context, format, args);
        }


        /// <summary>
        ///   <para>Logs a formatted message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="logType">Type of message e.g. warn or error etc.</param>
        /// <param name="logOptions">Option flags to treat the log message special.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogFormat(
            LogType logType,
            LogOption logOptions,
            Object context,
            string format,
            params object[] args
        )
        {
            Debug.LogFormat(logType, logOptions, context, format, args);
        }

        #endregion

        #region Assertion

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion<T>(IEnumerable<T> message)
        {
            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message));
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message)
        {
            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message));
        }

        /// <summary>
        ///   <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion(Color message)
        {
            Debug.unityLogger.Log(LogType.Assert, ObjectParser.ParseColor(message));
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion(object message)
        {
            Debug.unityLogger.Log(LogType.Assert, message);
        }

        #endregion

        #region AssertionContext

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion<T>(IEnumerable<T> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion(Color message, Object context)
        {
            Debug.unityLogger.Log(LogType.Assert, (object)ObjectParser.ParseColor(message), context);
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an assertion message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertion(object message, Object context)
        {
            Debug.unityLogger.Log(LogType.Assert, message, context);
        }

        #endregion

        #region AssertionContextFormat

        /// <summary>
        ///   <para>Logs a formatted assertion message to the Unity console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertionFormat(string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Assert, format, args);
        }


        /// <summary>
        ///   <para>Logs a formatted assertion message to the Unity console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogAssertionFormat(Object context, string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Assert, context, format, args);
        }

        #endregion

        #region Warning

        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning<T>(IEnumerable<T> message)
        {
            Debug.unityLogger.Log(LogType.Warning, ConvertEnumerableToObject(message));
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message)
        {
            Debug.unityLogger.Log(LogType.Warning, ConvertEnumerableToObject(message));
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning(string message)
        {
            Debug.unityLogger.Log(LogType.Warning, message);
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning(Color message)
        {
            Debug.unityLogger.Log(LogType.Warning, (object)ObjectParser.ParseColor(message));
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning(object message)
        {
            Debug.unityLogger.Log(LogType.Warning, message);
        }

        #endregion

        #region WarningContext

        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning<T>(IEnumerable<T> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Warning, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Warning, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning(string message, Object context)
        {
            Debug.unityLogger.Log(LogType.Warning, (object)message, context);
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning(Color message, Object context)
        {
            Debug.unityLogger.Log(LogType.Warning, (object)ObjectParser.ParseColor(message), context);
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarning(object message, Object context)
        {
            Debug.unityLogger.Log(LogType.Warning, message, context);
        }

        #endregion

        #region WarningFormat

        /// <summary>
        ///   <para>Logs a formatted warning message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarningFormat(string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Warning, format, args);
        }


        /// <summary>
        ///   <para>Logs a formatted warning message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogWarningFormat(Object context, string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Warning, context, format, args);
        }

        #endregion

        #region Error

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public static void LogError(object message)
        {
            Debug.unityLogger.Log(LogType.Error, message);
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError(string message)
        {
            Debug.unityLogger.Log(LogType.Error, message);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError<T>(IEnumerable<T> message)
        {
            Debug.unityLogger.Log(LogType.Error, ConvertEnumerableToObject(message));
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message)
        {
            Debug.unityLogger.Log(LogType.Error, ConvertEnumerableToObject(message));
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError(Color message)
        {
            Debug.unityLogger.Log(LogType.Error, (object)ObjectParser.ParseColor(message));
        }

        #endregion

        #region ErrorContext

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError<T>(IEnumerable<T> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Error, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> message, Object context)
        {
            Debug.unityLogger.Log(LogType.Error, ConvertEnumerableToObject(message), context);
        }

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError(Color message, Object context)
        {
            Debug.unityLogger.Log(LogType.Error, (object)ObjectParser.ParseColor(message), context);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogError(object message, Object context)
        {
            Debug.unityLogger.Log(LogType.Error, message, context);
        }

        #endregion

        #region ErrorFormat

        /// <summary>
        ///   <para>Logs a formatted error message to the Unity console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogErrorFormat(string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Error, format, args);
        }


        /// <summary>
        ///   <para>Logs a formatted error message to the Unity console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogErrorFormat(Object context, string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(LogType.Error, context, format, args);
        }

        #endregion

        #region Exception

        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="exception">Runtime Exception.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogException(Exception exception)
        {
            Debug.unityLogger.LogException(exception, (Object)null);
        }


        /// <summary>
        ///   <para>A variant of Debug.Log that logs an error message to the console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="exception">Runtime Exception.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void LogException(Exception exception, Object context)
        {
            Debug.unityLogger.LogException(exception, context);
        }

        #endregion


        /// <summary>
        ///   <para>Draws a line between specified start and end points.</para>
        /// </summary>
        /// <param name="start">Point in world space where the line should start.</param>
        /// <param name="end">Point in world space where the line should end.</param>
        /// <param name="color">Color of the line.</param>
        /// <param name="duration">How long the line should be visible for.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
        {
            Debug.DrawLine(start, end, color, duration, true);
        }


        /// <summary>
        ///   <para>Draws a line between specified start and end points.</para>
        /// </summary>
        /// <param name="start">Point in world space where the line should start.</param>
        /// <param name="end">Point in world space where the line should end.</param>
        /// <param name="color">Color of the line.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            Debug.DrawLine(start, end, color, 0.0f, true);
        }


        /// <summary>
        ///   <para>Draws a line between specified start and end points.</para>
        /// </summary>
        /// <param name="start">Point in world space where the line should start.</param>
        /// <param name="end">Point in world space where the line should end.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void DrawLine(Vector3 start, Vector3 end)
        {
            Debug.DrawLine(start, end, Color.white, 0.0f, true);
        }


        /// <summary>
        ///   <para>Draws a line from start to start + dir in world coordinates.</para>
        /// </summary>
        /// <param name="start">Point in world space where the ray should start.</param>
        /// <param name="dir">Direction and length of the ray.</param>
        /// <param name="color">Color of the drawn line.</param>
        /// <param name="duration">How long the line will be visible for (in seconds).</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
        {
            Debug.DrawRay(start, dir, color, duration, true);
        }


        /// <summary>
        ///   <para>Draws a line from start to start + dir in world coordinates.</para>
        /// </summary>
        /// <param name="start">Point in world space where the ray should start.</param>
        /// <param name="dir">Direction and length of the ray.</param>
        /// <param name="color">Color of the drawn line.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void DrawRay(Vector3 start, Vector3 dir, Color color)
        {
            Debug.DrawRay(start, dir, color, 0.0f, true);
        }


        /// <summary>
        ///   <para>Draws a line from start to start + dir in world coordinates.</para>
        /// </summary>
        /// <param name="start">Point in world space where the ray should start.</param>
        /// <param name="dir">Direction and length of the ray.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void DrawRay(Vector3 start, Vector3 dir)
        {
            Debug.DrawRay(start, dir, Color.white, 0.0f, true);
        }

        #region Assert

        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, (object)"Assertion failed");
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, Object context)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, (object)"Assertion failed", context);
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, object message)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, message);
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert<T>(bool condition, IEnumerable<T> message)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message));
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert<TKey, TValue>(bool condition, IEnumerable<KeyValuePair<TKey, TValue>> message)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message));
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, Color message)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, (object)ObjectParser.ParseColor(message));
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, string message)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, (object)message);
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert<T>(bool condition, IEnumerable<T> message, Object context)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert<TKey, TValue>(
            bool condition,
            IEnumerable<KeyValuePair<TKey, TValue>> message,
            Object context
        )
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, ConvertEnumerableToObject(message), context);
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, object message, Object context)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, message, context);
        }

        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, Color message, Object context)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, (object)ObjectParser.ParseColor(message), context);
        }


        /// <summary>
        ///   <para>Assert a condition and logs an error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void Assert(bool condition, string message, Object context)
        {
            if (condition) return;

            Debug.unityLogger.Log(LogType.Assert, (object)message, context);
        }

        #endregion

        #region AssertFormat

        /// <summary>
        ///   <para>Assert a condition and logs a formatted error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void AssertFormat(bool condition, string format, params object[] args)
        {
            if (condition) return;

            Debug.unityLogger.LogFormat(LogType.Assert, format, args);
        }


        /// <summary>
        ///   <para>Assert a condition and logs a formatted error message to the Unity console on failure.</para>
        /// </summary>
        /// <param name="condition">Condition you expect to be true.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <param name="context">Object to which the message applies.</param>
        [Conditional("ENABLE_DEBUGEX")]
        public static void AssertFormat(bool condition, Object context, string format, params object[] args)
        {
            if (condition) return;

            Debug.unityLogger.LogFormat(LogType.Assert, context, format, args);
        }

        #endregion


        static StringBuilder saveTextBuilder = new StringBuilder();
        public static DebugExProfile debugExProfile = null;
        static bool recordEnabled = false;


        public static void RecordStart()
        {
            if (debugExProfile == null)
            {
                LogError("DebugEx: 設定ファイルがありません！");
                return;
            }

            if (recordEnabled) return;

            saveTextBuilder.Clear();

            Application.logMessageReceived += HandleLog;
            Application.quitting += ForceQuit;

            recordEnabled = true;
        }


        public static void RecordStop()
        {
            if (!recordEnabled) recordEnabled = false;

            Application.logMessageReceived -= HandleLog;
            DateTime dt = DateTime.Now;
            string saveTitle = $"{debugExProfile.logSavePath}/{dt:yyyyMMdd}_{dt:hhmm}_editor";

            if (!Directory.Exists($"{Application.dataPath}/{debugExProfile.logSavePath}"))
            {
                LogError("DebugEx: logSavePathで指定されたディレクトリが存在しません！");
            }

            CreateTextFile(saveTextBuilder.ToString(), saveTitle);
        }


        static void ForceQuit()
        {
            Application.logMessageReceived -= HandleLog;
            Application.quitting -= ForceQuit;
        }


        static void HandleLog(string condition, string stackTrace, LogType type)
        {
            saveTextBuilder.Append($"[{type}]\n" + condition);
            saveTextBuilder.Append("\n\n");
            saveTextBuilder.Append(debugExProfile.saveStackTrace ? stackTrace + "\n" : "");
        }

        static void CreateTextFile(string content, string fileName)
        {
            string path = Application.dataPath + "/" + fileName + ".log";
            StreamWriter sw = File.CreateText(path);
            sw.Write(content.RemoveRichText());
            sw.Close();
        }

        /// <summary>
        ///   <para>Clear all the logs in Unity Editor.</para>
        /// </summary>
        public static void ClearConsoleAll()
        {
            DebugUtil.GetClearConsoleMethodInfo()?.Invoke(new object(), null);
        }


        /// <summary>
        ///   <para>Clear the error logs in Unity Editor.</para>
        /// </summary>
        public static void ClearConsoleError()
        {
            Debug.ClearDeveloperConsole();
        }


        /// <summary>
        ///   <para>Pauses the editor.</para>
        /// </summary>
        public static void Break()
        {
            Debug.Break();
        }
    }


    public static class RichText
    {
        public static string Color(this string str, Color color) =>
            $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{str}</color>";


        public static string Bold(this string str) => $"<b>{str}</b>";


        public static string Italic(this string str) => $"<i>{str}</i>";


        public static string Size(this string str, int size) => $"<size={size}>{str}</size>";

        public static string RemoveRichText(this string input)
        {
            input = RemoveRichTextDynamicTag(input, "color");
            input = RemoveRichTextDynamicTag(input, "size");

            input = RemoveRichTextTag(input, "b");
            input = RemoveRichTextTag(input, "i");

            return input;
        }


        static string RemoveRichTextDynamicTag(string input, string tag)
        {
            int index = -1;
            while (true)
            {
                index = input.IndexOf($"<{tag}=", StringComparison.Ordinal);
                if (index != -1)
                {
                    int endIndex = input.Substring(index, input.Length - index).IndexOf('>');
                    if (endIndex > 0)
                        input = input.Remove(index, endIndex + 1);
                    continue;
                }

                input = RemoveRichTextTag(input, tag, false);
                return input;
            }
        }

        static string RemoveRichTextTag(string input, string tag, bool isStart = true)
        {
            while (true)
            {
                int index = input.IndexOf(isStart ? $"<{tag}>" : $"</{tag}>", StringComparison.Ordinal);
                if (index != -1)
                {
                    input = input.Remove(index, 2 + tag.Length + (!isStart).GetHashCode());
                    continue;
                }

                if (isStart)
                    input = RemoveRichTextTag(input, tag, false);
                return input;
            }
        }
    }
}