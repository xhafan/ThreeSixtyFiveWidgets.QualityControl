namespace ThreeSixtyFiveWidgets.QualityControl.LogEntryParsers
{
    public interface ILogEntryParser
    {
        LogEntry ParseLogEntry(string logEntryLine);
    }
}