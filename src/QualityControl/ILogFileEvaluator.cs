using System.IO;

namespace ThreeSixtyFiveWidgets.QualityControl
{
    public interface ILogFileEvaluator
    {
        string EvaluateLogFile(string logContentsStr);
        string EvaluateLogFile(Stream logStream);
    }
}