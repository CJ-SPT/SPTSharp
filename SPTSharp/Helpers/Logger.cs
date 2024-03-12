using SPTSharp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Helpers
{
    public enum LogLevel
    {
        NONE = -1,
        INFO = 0,
        WARNING = 1,
        ERROR = 2,
        EXCEPTION = 3,
        DEBUG = 4,
        ALL = 5,
    }

    public static class Logger
    {
        static LogLevel level => LogLevel.ALL; //Singleton<ConfigController>.Instance.core.LogLevel;

        // Logs with specific color given, and a custom prefix
        public static void LogWithColor(object msg, ConsoleColor color, string prefix = "SPTSharp")
        {
            if (level != LogLevel.NONE)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{prefix}: {msg}");
                Console.ResetColor();
            }
        }

        // Logs info in a white color
        public static void LogInfo(object msg)
        {
            if (level >= LogLevel.INFO)
            {
                Console.WriteLine($"INFO: {msg}");
            }       
        }

        // Logs warning in a yellow color
        public static void LogWarning(object msg) 
        {
            if (level >= LogLevel.WARNING)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNING: {msg}");
                Console.ResetColor();
            }     
        }

        // Logs error in red color
        public static void LogError(object msg) 
        {
            if (level >= LogLevel.ERROR)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {msg}");
                Console.ResetColor();
            }           
        }

        // Logs exception in red color
        public static void LogException(Exception ex)
        {
            if (level >= LogLevel.EXCEPTION)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"EXCEPTION: {ex.Message}");
                Console.ResetColor();
            }         
        }

        // Logs debug in a gray color
        public static void LogDebug(object msg)
        {
            if (level >= LogLevel.DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"DEBUG: {msg}");
                Console.ResetColor();
            }
        }

        // Writes the logging output to disk
        private static void LogToDisk(object msg)
        {
            
        } 
    }
}
