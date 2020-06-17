using System;
using System.Collections.Generic;
using System.Linq;
using Logger.Enums;
using Logger.Interfaces;
using Logger.Targets;

namespace Logger
{
    public static class LoggerKernel
    {
        private static readonly IDictionary<Type, LogSystem> RegisteredLoggers = new Dictionary<Type, LogSystem>();

        private static readonly ILoggerTarget DefaultLogTarget = new UnityLogTarget();
        private static readonly IList<ILoggerTarget> Targets = new List<ILoggerTarget>();

        public static void RegisterTarget(ILoggerTarget target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target), "Logger target cannot be null");
            
            Targets.Add(target);
        }
        
        public static void Log(LogLevel logLevel, Type source, params object[] param)
        {
            LogToTargets(logLevel, source, string.Join(Environment.NewLine, param));
        }

        internal static void Log(LogLevel logLevel, Type source, string message)
        {
            LogToTargets(logLevel, source, message);
        }

        internal static LogSystem For(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type), "Logger source type cannot be null");

            if (RegisteredLoggers.ContainsKey(type))
                return RegisteredLoggers[type];

            return RegisteredLoggers[type] = new LogSystem(type);
        }

        private static void LogToTargets(LogLevel logLevel, Type source, string message)
        {
            if (!Targets.Any())
            {
                DefaultLogTarget.Log(logLevel,source,message);
                return;
            }
            
            foreach (var loggerClient in Targets)
            {
                try
                {
                    loggerClient.Log(logLevel, source, message);
                }
                catch (Exception ex)
                {
                    DefaultLogTarget.Log(LogLevel.Error, typeof(LoggerKernel), ex.Message);
                }
            }
        }
    }
}