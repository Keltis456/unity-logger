namespace Logger
{
    public interface ILog
    {
        void Debug(params object[] args);
        void Debug(string message);
        void Warning(string message);
        void Error(string message);
    }
}