using System;

namespace Widgets365.QualityControl.LogEntryParsers
{
    public interface ILogEntryParser
    {
        (DateTime LoggedOn, double Value) ParseLogEntry(string logEntryLine);
    }
}