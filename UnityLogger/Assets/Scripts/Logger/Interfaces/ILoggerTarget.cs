using System;
using Logger.Enums;

namespace Logger.Interfaces
{
    public interface ILoggerTarget
    {
        void Log(LogLevel logLevel, Type source, string message);
    }
}