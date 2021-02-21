using System.IO;
using Widgets365.QualityControl.ReferenceParsers;

namespace Widgets365.QualityControl
{
    public class LogFileEvaluator : ILogFileEvaluator
    {
        private readonly IReferenceParser _referenceParser;

        public LogFileEvaluator(IReferenceParser referenceParser)
        {
            _referenceParser = referenceParser;
        }

        public string EvaluateLogFile(string logContentsStr)
        {
            using (var reader = new StringReader(logContentsStr))
            {
                var referenceLine = reader.ReadLine();
                var referenceValuesBySensorType = _referenceParser.ParseReference(referenceLine);

                // while ((line = reader.ReadLine()) != null)
                // {
                //     
                // }
            }

            return null;
        }
    }
}
