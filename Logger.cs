using System;
using System.IO;

namespace Squirrel_Logger {
    public class Logger {
        private readonly StreamWriter _loggerWriter;

        /// <summary>
        /// Sets the name and extension of the log file.
        /// </summary>
        /// <param name="loggerName">The name you wish to use</param>
        /// <param name="loggerExtension">The extension you wish to use</param>
        public Logger(string loggerName, string loggerExtension) => _loggerWriter = new StreamWriter($"{loggerName}.{loggerExtension}");

        /// <summary>
        /// Sets the name of the log file.
        /// </summary>
        /// <param name="loggerName">The name you wish to use</param>
        public Logger(string loggerName) => _loggerWriter = new StreamWriter($"{loggerName}.log");

        /// <summary>
        /// Outputs information either to a log file or to the console dependent on what your request
        /// </summary>
        /// <param name="outputType">The output type you with to use Either 'File' or 'Console'</param>
        /// <param name="level">The error level of the log Either 'Debug' or 'Info' or 'Error' or 'Fatal'</param>
        /// <param name="message">A string message</param>
        public void Log(OutputType outputType, Level level, string message) {
            switch (outputType) {
                case OutputType.File:
                    _loggerWriter.WriteLine();
                    switch (level) {
                        case Level.Debug:
                            _loggerWriter.Write("====== DEBUG ======");
                            break;
                        case Level.Info:
                            _loggerWriter.Write("====== INFO  ======");
                            break;
                        case Level.Error:
                            _loggerWriter.Write("====== ERROR ======");
                            break;
                        case Level.Fatal:
                            _loggerWriter.Write("====== FATAL ======");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
                    _loggerWriter.Write(message);
                    break;
                case OutputType.Console:
                    Console.WriteLine();
                    switch (level) {
                        case Level.Debug:
                            CenterText("====== DEBUG ======");
                            break;
                        case Level.Info:
                            CenterText("====== INFO  ======");
                            break;
                        case Level.Error:
                            CenterText("====== ERROR ======");
                            break;
                        case Level.Fatal:
                            CenterText("====== FATAL ======");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
                    Console.WriteLine(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(outputType), outputType, null);
            }
        }

        /// <summary>
        /// Outputs information either to a log file or to the console dependent on what your request
        /// </summary>
        /// <param name="outputType">The output type you with to use Either 'File' or 'Console'</param>
        /// <param name="level">The error level of the log Either 'Debug' or 'Info' or 'Error' or 'Fatal'</param>
        /// <param name="ex">A exception message</param>
        public void Log(OutputType outputType, Level level, Exception ex) {
            switch (outputType) {
                case OutputType.File:
                    _loggerWriter.WriteLine();
                    switch (level) {
                        case Level.Debug:
                            _loggerWriter.Write("====== DEBUG ======");
                            break;
                        case Level.Info:
                            _loggerWriter.Write("====== INFO  ======");
                            break;
                        case Level.Error:
                            _loggerWriter.Write("====== ERROR ======");
                            break;
                        case Level.Fatal:
                            _loggerWriter.Write("====== FATAL ======");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
                    _loggerWriter.Write(StringBuilder(ex));
                    break;
                case OutputType.Console:
                    Console.WriteLine();
                    switch (level) {
                        case Level.Debug:
                            CenterText("====== DEBUG ======");
                            break;
                        case Level.Info:
                            CenterText("====== INFO  ======");
                            break;
                        case Level.Error:
                            CenterText("====== ERROR ======");
                            break;
                        case Level.Fatal:
                            CenterText("====== FATAL ======");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
                    Console.WriteLine(StringBuilder(ex));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(outputType), outputType, null);
            }
        }

        /// <summary>
        /// Centers the console text based on a given string
        /// </summary>
        /// <param name="textToCenter">string to center</param>
        private static void CenterText(string textToCenter) => Console.SetCursorPosition((Console.WindowWidth - textToCenter.Length) / 2, Console.CursorTop);

        /// <summary>
        /// This takes the exception and turns it into something readable.
        /// </summary>
        /// <param name="ex">The exception we are converting to be readable</param>
        /// <returns>A string</returns>
        private static string StringBuilder(Exception ex) {
            return $"{ex.Message}\n" +
                   $"{ex.InnerException}\n" +
                   $"{ex.Source}\n" +
                   $"{ex.TargetSite}\n" +
                   $"{ex.Data}";
        }

        /// <summary>
        /// This disposes everything.
        /// </summary>
        public void Dispose() => _loggerWriter.Close();

        public enum OutputType {
            File,
            Console
        }

        public enum Level {
            Debug,
            Info,
            Error,
            Fatal
        }
    }
}
