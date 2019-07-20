using System;
using System.IO;

namespace Squirrel_Logger {
    internal class FileLogger : IDisposable {

        private StreamWriter _loggerWriter;
        private StreamReader _loggerReader;
        private string _logToWrite;

        internal void Log(string logName, string logFileName, bool deleteOldFile, string message, Logger.Level level) {
            if (File.Exists(logFileName)) {
                switch (deleteOldFile) {
                    case true:
                        File.Delete(logFileName);
                        _loggerWriter = new StreamWriter(logFileName);
                        break;
                    case false:
                        _loggerReader = new StreamReader(logFileName);
                        _logToWrite = _loggerReader.ReadToEnd();
                        _loggerReader.Dispose();

                        _loggerWriter = new StreamWriter(logFileName);
                        _loggerWriter.WriteLine(_logToWrite);
                        break;
                }
            }
            else {
                _loggerWriter = new StreamWriter(logFileName);
            }

            switch (level) {
                case Logger.Level.Debug:
                    _loggerWriter.WriteLine("====== DEBUG ======");
                    break;
                case Logger.Level.Info:
                    _loggerWriter.WriteLine("====== INFO  ======");
                    break;
                case Logger.Level.Error:
                    _loggerWriter.WriteLine("====== ERROR ======");
                    break;
                case Logger.Level.Fatal:
                    _loggerWriter.WriteLine("====== FATAL ======");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }

            WriteTime();
            _loggerWriter.WriteLine(message);

        }

        private void WriteTime() => _loggerWriter.WriteLine(DateTime.Now);

        public void Dispose() {
            _loggerWriter?.Dispose();
            _loggerReader?.Dispose();
        }
    }
}
