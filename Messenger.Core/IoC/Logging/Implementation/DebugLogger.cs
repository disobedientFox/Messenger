using System.Diagnostics;

namespace Messenger.Core
{
    /// <summary>
    /// Logs the messages to the Debug log
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Logs the given message to the system Console
        /// </summary>
        public void Log(string message, LogLevel level)
        {
            // The default category
            var category = default(string);

            // Color console based on level
            switch (level)
            {
                case LogLevel.Debug:
                    category = "information";
                    break;

                case LogLevel.Verbose:
                    category = "verbose";
                    break;

                case LogLevel.Warning:
                    category = "warning";
                    break;

                case LogLevel.Error:
                    category = "error";
                    break;

                case LogLevel.Success:
                    category = "-----";
                    break;
            }

            Debug.WriteLine(message, category);
        }
    }
}