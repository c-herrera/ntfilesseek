using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NTOSFIleSeeker
{

    public class SimpleLogger
    {
        private string DatetimeFormat;
        private string LogFileName;

        private int errorCount = 0;   // errors 
        private int failureCount = 0; // fatal errors
        private int warningCount = 0; // warnings

        /// <summary>
        /// Supported log level
        /// </summary>
        [Flags]
        private enum LogLevel
        {
            TRACE, INFO, DEBUG, WARNING, ERROR, FATAL
        };

        /// <summary>
        /// [Enum] Log type (text, xml, no log)
        /// </summary>
        [Flags]
        public enum LogType
        {
            NoLog, LogInTextFormat
        };

        /// <summary>
        /// Initialize a new instance of SimpleLogger class.
        /// Log file will be created automatically if not yet exists, else it can be either a fresh new file or append to the existing file.
        /// Default is create a fresh new log file.
        /// </summary>
        /// <param name="append">True to append to existing log file, False to overwrite and create new log file</param>
        public SimpleLogger(bool append = false)
        {
            DatetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            LogFileName = Assembly.GetExecutingAssembly().GetName().Name + ".log";

            // Log file header line
            string logHeader = LogFileName + " is created.";
            try
            {
                if (!File.Exists(LogFileName))
                {
                    WriteLine(DateTime.Now.ToString(DatetimeFormat) + " " + logHeader, false);
                }
                else
                {
                    if (append == false)
                        WriteLine(DateTime.Now.ToString(DatetimeFormat) + " " + logHeader, false);
                }
            }
            catch (Exception excp)
            {
                throw excp;
            }

        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }

        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
            errorCount++;
        }

        /// <summary>
        /// Log a fatal error message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(LogLevel.FATAL, text);
            failureCount++;
        }

        /// <summary>
        /// Log an info message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        /// <summary>
        /// Log a trace message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteFormattedLog(LogLevel.TRACE, text);
        }

        /// <summary>
        /// Log a waning message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteFormattedLog(LogLevel.WARNING, text);
            warningCount++;
        }

        /// <summary>
        /// Format a log message based on log level
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="text">Log message</param>
        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.TRACE:
                    pretext = DateTime.Now.ToString(DatetimeFormat) + " [TRACE]   ";
                    break;
                case LogLevel.INFO:
                    pretext = DateTime.Now.ToString(DatetimeFormat) + " [INFO]    ";
                    break;
                case LogLevel.DEBUG:
                    pretext = DateTime.Now.ToString(DatetimeFormat) + " [DEBUG]   ";
                    break;
                case LogLevel.WARNING:
                    pretext = DateTime.Now.ToString(DatetimeFormat) + " [WARNING] ";
                    break;
                case LogLevel.ERROR:
                    pretext = DateTime.Now.ToString(DatetimeFormat) + " [ERROR]   ";
                    break;
                case LogLevel.FATAL:
                    pretext = DateTime.Now.ToString(DatetimeFormat) + " [FATAL]   ";
                    break;
                default:
                    pretext = "";
                    break;
            }

            WriteLine(pretext + text);
        }

        /// <summary>
        /// Write a line of formatted log message into a log file
        /// </summary>
        /// <param name="text">Formatted log message</param>
        /// <param name="append">True to append, False to overwrite the file</param>
        /// <exception cref="System.IO.IOException"></exception>
        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (StreamWriter Writer = new StreamWriter(LogFileName, append, Encoding.UTF8))
                {
                    if (text != string.Empty)
                        Writer.WriteLine(text);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~SimpleLogger()
        {
            WriteFormattedLog(LogLevel.INFO, "Total of Errors :" + errorCount);
            WriteFormattedLog(LogLevel.INFO, "Total of Fatal Errors :" + failureCount);
            WriteFormattedLog(LogLevel.INFO, "Total of Warnings :" + warningCount);
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalErrors
        {
            get { return errorCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalFatalErrors
        {
            get { return failureCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalWarnings
        {
            get { return warningCount; }
        }


    }
}
