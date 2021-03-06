﻿using System;

namespace Messenger.Core
{
    /// <summary>
    /// Logs the messages to the console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            var consoleOldColor = Console.ForegroundColor;
            var consoleColor = ConsoleColor.White;

            switch(level)
            {
                case LogLevel.Warning:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;

                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Blue;
                    break;

                case LogLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;

                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;

                case LogLevel.Success:
                    consoleColor = ConsoleColor.Green;
                    break;
            }

            Console.ForegroundColor = consoleColor;

            Console.WriteLine(message);

            Console.ForegroundColor = consoleOldColor;
        }
    }
}