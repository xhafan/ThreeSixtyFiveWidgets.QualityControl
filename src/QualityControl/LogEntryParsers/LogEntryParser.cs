using System;
using System.Globalization;

namespace Widgets365.QualityControl.LogEntryParsers
{
    public class LogEntryParser : ILogEntryParser
    {
        public (DateTime LoggedOn, double Value) ParseLogEntry(string logEntryLine)
        {
            var logEntryLineSplit = logEntryLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (logEntryLineSplit.Length > 2)
            {
                throw new ArgumentException("Too many entries in log entry.");
            }
            if (!double.TryParse(logEntryLineSplit[1], out var value))
            {
                throw new ArgumentException("Invalid value in log entry.");
            }
            var loggedOn = DateTime.ParseExact(logEntryLineSplit[0], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            return (loggedOn, value);
        }
    }
}