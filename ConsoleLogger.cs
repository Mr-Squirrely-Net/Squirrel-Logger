using System;

namespace Squirrel_Logger {
    internal class ConsoleLogger {

        internal void Log(string logName, string logFileName, string message, Logger.Level level) {

            switch (level) {
                case Logger.Level.Debug:
                    CenterText("====== DEBUG ======");
                    break;
                case Logger.Level.Info:
                    CenterText("====== INFO  ======");
                    break;
                case Logger.Level.Error:
                    CenterText("====== ERROR ======");
                    break;
                case Logger.Level.Fatal:
                    CenterText("====== FATAL ======");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }

            Console.WriteLine(message);
        }

        private static void CenterText(string textToCenter) {
            Console.SetCursorPosition((Console.WindowWidth - textToCenter.Length) / 2, Console.CursorTop);
            Console.WriteLine(textToCenter);
        }

    }
}
