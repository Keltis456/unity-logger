using System;

namespace Logger
{
    public static class LogFactory
    {
        public static ILog CreateFor<T>() => LoggerKernel.For(typeof(T));

        public static ILog Create(Type type) => LoggerKernel.For(type);
    }
}