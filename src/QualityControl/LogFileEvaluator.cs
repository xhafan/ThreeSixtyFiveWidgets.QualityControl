using System.IO;
using Widgets365.QualityControl.ReferenceParsers;

namespace Widgets365.QualityControl
{
    public class LogFileEvaluator : ILogFileEvaluator
    {
        private readonly IReferenceParser _referenceParser;
        private readonly ISensorIdentifierParser _sensorIdentifierParser;

        public LogFileEvaluator(
            IReferenceParser referenceParser,
            ISensorIdentifierParser sensorIdentifierParser
            )
        {
            _referenceParser = referenceParser;
            _sensorIdentifierParser = sensorIdentifierParser;
        }

        public string EvaluateLogFile(string logContentsStr)
        {
            using (var reader = new StringReader(logContentsStr))
            {
                var referenceLine = reader.ReadLine();
                var referenceValuesBySensorType = _referenceParser.ParseReference(referenceLine);
                var sensorIdentifierLine = reader.ReadLine();
                var sensorTypeAndName = _sensorIdentifierParser.ParseSensorIdentifier(sensorIdentifierLine);

                // while ((line = reader.ReadLine()) != null)
                // {
                //     
                // }
            }

            return null;
        }
    }
}
