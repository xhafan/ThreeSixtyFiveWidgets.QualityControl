namespace Widgets365.QualityControl.LogEntryParsers
{
    public interface ILogEntryParser
    {
        LogEntry ParseLogEntry(string logEntryLine);
    }
}