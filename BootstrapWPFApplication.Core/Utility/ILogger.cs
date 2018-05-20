using System;

namespace BootstrapWPFApplication.Core.Utility
{
    public interface ILogger
    {
        void Log(LogCategory logCategory, string logMessage);
        void Log(Exception exception);
    }
}
