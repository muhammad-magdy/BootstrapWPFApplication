using BootstrapWPFApplication.Core.Utility;
using NLog;
using System;

namespace BootstrapWPFApplication.Infrastructure.Utility.NLogger
{
    public class AppLogger : Core.Utility.ILogger
    {
        #region private attributes
        private Logger _logger;
        private volatile static object _lock = new object();
        private static AppLogger _instance;
        #endregion

        #region properties
        public static AppLogger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppLogger();
                    }
                    return _instance;
                }
            }
        }
        #endregion

        public AppLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        #region ILogger implementation
        public void Log(LogCategory logCategory, string logMessage)
        {
            switch (logCategory)
            {
                case LogCategory.Trace:
                    _logger.Trace(logMessage);
                    break;
                case LogCategory.Debug:
                    _logger.Debug(logMessage);
                    break;
                case LogCategory.Info:
                    _logger.Info(logMessage);
                    break;
                case LogCategory.Warn:
                    _logger.Warn(logMessage);
                    break;
                case LogCategory.Error:
                    _logger.Error(logMessage);
                    break;
                case LogCategory.Fatal:
                    _logger.Fatal(logMessage);
                    break;
                default:
                    break;
            }
        }

        public void Log(Exception exception)
        {
            _logger.Error(exception);
        }
        #endregion
    }
}
