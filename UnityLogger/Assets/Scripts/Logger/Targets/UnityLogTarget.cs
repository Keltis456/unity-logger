using System;
using Logger.Enums;
using Logger.Interfaces;
using UnityEngine;

namespace Logger.Targets
{
    public class UnityLogTarget : ILoggerTarget
    {
        public void Log(LogLevel logLevel, Type source, string message) =>
            Debug.unityLogger.Log(logLevel.ToUnity(), FormatMessage(source, message));
        
        private static string FormatMessage(Type source, string message) =>
            message.StartsWith("[") ? message : $"[{source}]: {message}";
    }
}