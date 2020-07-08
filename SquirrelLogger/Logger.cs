namespace SquirrelLogger {
    public class Logger {

        //Todo: add debug logger
        //Todo: add github logger
        //Todo: add console logger

        public string LoggerName { get; set; }

        public Logger(string loggerName) => LoggerName = loggerName;

        public enum Level {
            Debug,
            Error,
            Info,
            Critical,
            Fatal
        }
    }
}
