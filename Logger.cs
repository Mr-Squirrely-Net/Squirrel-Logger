using System;

namespace Squirrel_Logger {
    public class Logger : IDisposable {
        private readonly string _logName;
        private readonly string _logFileName;
        private readonly bool _deleteOldLog;

        private FileLogger _fileLogger;
        private ConsoleLogger _consoleLogger;

        public Logger(string logName, string logFileName, bool deleteOldLog) {
            _logName = logName;
            _logFileName = logFileName;
            _deleteOldLog = deleteOldLog;
            StartLoggers();
        }

        public Logger(string logName, bool deleteOldLog) {
            _logName = logName;
            _logFileName = "log";
            _deleteOldLog = deleteOldLog;
            StartLoggers();
        }

        private void StartLoggers() {
            _fileLogger = new FileLogger();
            _consoleLogger = new ConsoleLogger();
        }
        
        public void LogFile(string message, Level level) => _fileLogger.Log(_logName, _logFileName, _deleteOldLog, message, level);
        public void LogFile(Exception ex, Level level) => _fileLogger.Log(_logName, _logFileName, _deleteOldLog, StringBuilder(ex), level);
        public void LogConsole(string message, Level level) => _consoleLogger.Log(_logName, _logFileName, message, level);
        public void LogConsole(Exception ex, Level level) => _consoleLogger.Log(_logName, _logFileName, StringBuilder(ex), level);

        private static string StringBuilder(Exception ex) =>
            "\n" +
            $"Message: {ex.Message}\n" +
            $"Inner Exception: {ex.InnerException}\n" +
            $"Source: {ex.Source}\n" +
            $"TargetSite: {ex.TargetSite}\n" +
            $"Data: {ex.Data}";

        public enum Level {
            Debug,
            Info,
            Error,
            Fatal
        }

        public void Dispose() => _fileLogger?.Dispose();
    }
}
