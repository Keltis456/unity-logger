using System.Collections.Generic;
using UnityEngine;

namespace Logger.Enums
{
    public static class EnumsExtension
    {
        private static readonly Dictionary<LogLevel, LogType> LogTypeMap = new Dictionary<LogLevel, LogType>
        {
            { LogLevel.Debug, LogType.Log },
            { LogLevel.Error, LogType.Error },
            { LogLevel.Warning, LogType.Warning },
        };

        public static LogType ToUnity(this LogLevel logLevel) =>
            LogTypeMap.ContainsKey(logLevel)
                ? LogTypeMap[logLevel]
                : LogType.Log;
    }
}