using System;
using System.IO;

namespace Squirrel_Logger {
    public class Logger {
        private readonly StreamWriter _loggerWriter;
        /// <summary>
        /// Sets the name of the log file.
        /// </summary>
        /// <param name="loggerName">The name you wish to use</param>
        public Logger(string loggerName) => _loggerWriter = new StreamWriter($"{loggerName}.log");
        /// <summary>
        /// Outputs to the log using a string message.
        /// </summary>
        /// <param name="message">Message to output</param>
        /// <seealso cref="LogInfo(Exception)">Use this for exceptions</seealso>
        public void LogInfo(string message) {
            _loggerWriter.WriteLine();
            _loggerWriter.Write("====== INFO ======");
            _loggerWriter.Write(message);
        }
        /// <summary>
        /// Outputs to the log using an exception.
        /// </summary>
        /// <param name="ex">The exception you wish to output</param>
        public void LogInfo(Exception ex) {
            _loggerWriter.WriteLine();
            _loggerWriter.Write("====== INFO ======");
            _loggerWriter.Write(StringBuilder(ex));
        }
        /// <summary>
        /// Outputs to the log using a string message.
        /// </summary>
        /// <param name="message">Message to output</param>
        /// <seealso cref="LogError(Exception)">Use this for exceptions</seealso>
        public void LogError(string message) {
            _loggerWriter.WriteLine();
            _loggerWriter.Write("====== ERROR ======");

        }
        /// <summary>
        /// Outputs to the log using an exception.
        /// </summary>
        /// <param name="ex">The exception you wish to output</param>
        public void LogError(Exception ex) {
            _loggerWriter.WriteLine();
            _loggerWriter.Write("====== ERROR ======");
            _loggerWriter.Write(StringBuilder(ex));
        }
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
        public void Dispose() {
            _loggerWriter.Close();
        }
    }
}
