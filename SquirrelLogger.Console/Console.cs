using System;
using System.Collections.Generic;
using System.Text;

namespace SquirrelLogger.ConsoleLogger {
    public static class ConsoleLogger {

        public static void LogConsole(this Logger logger, string message) {
            Console.WriteLine($"{logger.LoggerName} {message}");
        }

    }
}
