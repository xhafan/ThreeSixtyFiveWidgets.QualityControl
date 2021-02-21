namespace Widgets365.QualityControl
{
    public interface ILogFileEvaluator
    {
        string EvaluateLogFile(string logContentsStr);
    }
}