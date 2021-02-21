using System;
using System.IO;
using Widgets365.QualityControl.LineMeaningDetectors;
using Widgets365.QualityControl.LogEntryParsers;
using Widgets365.QualityControl.ReferenceParsers;
using Widgets365.QualityControl.SensorIdentifierParsers;

namespace Widgets365.QualityControl
{
    public class LogFileEvaluator : ILogFileEvaluator
    {
        private readonly IReferenceParser _referenceParser;
        private readonly ISensorIdentifierParser _sensorIdentifierParser;
        private readonly ILineMeaningDetector _lineMeaningDetector;
        private readonly ILogEntryParser _logEntryParser;

        public LogFileEvaluator(
            IReferenceParser referenceParser,
            ISensorIdentifierParser sensorIdentifierParser,
            ILineMeaningDetector lineMeaningDetector,
            ILogEntryParser logEntryParser
            )
        {
            _referenceParser = referenceParser;
            _sensorIdentifierParser = sensorIdentifierParser;
            _lineMeaningDetector = lineMeaningDetector;
            _logEntryParser = logEntryParser;
        }

        public string EvaluateLogFile(string logContentsStr)
        {
            using (var reader = new StringReader(logContentsStr))
            {
                var referenceLine = reader.ReadLine();
                var referenceValuesBySensorType = _referenceParser.ParseReference(referenceLine);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var lineMeaning = _lineMeaningDetector.DetectLineMeaning(line);
                    switch (lineMeaning)
                    {
                        case LogLineMeaning.SensorIdentifier:
                            var sensorTypeAndName = _sensorIdentifierParser.ParseSensorIdentifier(line);
                            break;
                        case LogLineMeaning.LogEntry:
                            var logEntry = _logEntryParser.ParseLogEntry(line);
                            break;
                        default:
                            throw new ArgumentException("Unknown line meaning.");
                    }
                }
            }

            return null;
        }
    }
}
