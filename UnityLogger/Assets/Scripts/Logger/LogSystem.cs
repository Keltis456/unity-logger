using System;
using Logger.Enums;

namespace Logger
{
    internal class LogSystem : ILog
    {
        private readonly Type targetType;

        internal LogSystem(Type targetType) => this.targetType = targetType;

        public void Debug(params object[] args) =>
            LoggerKernel.Log(LogLevel.Debug, targetType, args);

        public void Debug(string message) => 
            LoggerKernel.Log(LogLevel.Debug, targetType, message);

        public void Warning(string message) => 
            LoggerKernel.Log(LogLevel.Warning, targetType, message);
        
        public void Error(string message) => 
            LoggerKernel.Log(LogLevel.Error, targetType, message);
    }
}