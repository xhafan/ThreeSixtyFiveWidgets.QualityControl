namespace ThreeSixtyFiveWidgets.QualityControl
{
    public interface ILogFileEvaluator
    {
        string EvaluateLogFile(string logContentsStr);
    }
}