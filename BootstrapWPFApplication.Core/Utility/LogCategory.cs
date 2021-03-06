﻿namespace BootstrapWPFApplication.Core.Utility
{
    public enum LogCategory
    {
        Trace, // - very detailed logs, which may include high-volume information such as protocol payloads. This log level is typically only enabled during development
        Debug, // - debugging information, less detailed than trace, typically not enabled in production environment.
        Info, // - information messages, which are normally enabled in production environment
        Warn, // - warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
        Error, // - error messages
        Fatal, // - very serious errors
    }
}
