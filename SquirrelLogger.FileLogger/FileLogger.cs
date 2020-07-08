using System;
using System.IO;

namespace SquirrelLogger.FileLogger {
    public static class FileLogger {

        private static StreamWriter _loggerWriter;
        private static StreamReader _loggerReader;
        private static string _logToWrite;

        private static string _fileName;
        private static bool _deleteOldFile;

        public static void SetupFileLogger(this Logger logger, string fileName, bool deleteOldFile) {
            _fileName = fileName;
            _deleteOldFile = deleteOldFile;
        }

        public static void LogFile(this Logger logger, Logger.Level level, string fileName, bool deleteOldFile, string message) => Log(logger, fileName, deleteOldFile, message, false, level);
        public static void LogFile(this Logger logger, string fileName, bool deleteOldFile, string message) => Log(logger, fileName, deleteOldFile, message, true);

        public static void LogFile(this Logger logger, Logger.Level level, string message) => Log(logger, _fileName, _deleteOldFile, message, false, level);
        public static void LogFile(this Logger logger, string message) => Log(logger, _fileName, _deleteOldFile, message, true);

        private static void Log(this Logger logger, string fileName, bool deleteOldFile, string message, bool noLevel, Logger.Level level = Logger.Level.Info) {
            if (File.Exists(fileName)) {
                switch (deleteOldFile) {
                    case true:
                        File.Delete(fileName);
                        _loggerWriter = new StreamWriter(fileName);
                        break;
                    case false:
                        _loggerReader = new StreamReader(fileName);
                        _logToWrite = _loggerReader.ReadToEnd();
                        _loggerReader.Dispose();

                        _loggerWriter = new StreamWriter(fileName);
                        _loggerWriter.WriteLine(_logToWrite);
                        break;
                }
            }
            else {
                _loggerWriter = new StreamWriter($"{Environment.CurrentDirectory}\\{fileName}");
            }

            if (!noLevel) {
                switch (level) {
                    case Logger.Level.Debug:
                        _loggerWriter.WriteLine("|DEBUG|");
                        break;
                    case Logger.Level.Error:
                        _loggerWriter.WriteLine("|ERROR|");
                        break;
                    case Logger.Level.Info:
                        _loggerWriter.WriteLine("|INFO|");
                        break;
                    case Logger.Level.Fatal:
                    case Logger.Level.Critical:
                        _loggerWriter.WriteLine("|FATAL|");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(level), level, null);
                }
            }
            
            _loggerWriter.WriteLine($"{DateTime.Now}: {message}");

            _loggerReader?.Dispose();
            _loggerWriter?.Dispose();
        }

    }
}
