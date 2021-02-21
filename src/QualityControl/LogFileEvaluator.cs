using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;
using ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors;
using ThreeSixtyFiveWidgets.QualityControl.LogEntryParsers;
using ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers;
using ThreeSixtyFiveWidgets.QualityControl.SensorIdentifierParsers;

namespace ThreeSixtyFiveWidgets.QualityControl
{
    public class LogFileEvaluator : ILogFileEvaluator
    {
        private readonly IReferenceParser _referenceParser;
        private readonly ISensorIdentifierParser _sensorIdentifierParser;
        private readonly ILineMeaningDetector _lineMeaningDetector;
        private readonly ILogEntryParser _logEntryParser;
        private readonly IBrandingStrategyDeterminer _brandingStrategyDeterminer;

        public LogFileEvaluator(
            IReferenceParser referenceParser,
            ISensorIdentifierParser sensorIdentifierParser,
            ILineMeaningDetector lineMeaningDetector,
            ILogEntryParser logEntryParser,
            IBrandingStrategyDeterminer brandingStrategyDeterminer
            )
        {
            _referenceParser = referenceParser;
            _sensorIdentifierParser = sensorIdentifierParser;
            _lineMeaningDetector = lineMeaningDetector;
            _logEntryParser = logEntryParser;
            _brandingStrategyDeterminer = brandingStrategyDeterminer;
        }

        public string EvaluateLogFile(string logContentsStr)
        {
            return EvaluateLogFile(new MemoryStream(Encoding.UTF8.GetBytes(logContentsStr)));
        }

        public string EvaluateLogFile(Stream logStream)
        {
            using var reader = new StreamReader(logStream);
            var referenceLine = reader.ReadLine();
            var referenceValuesBySensorType = _referenceParser.ParseReference(referenceLine);

            var sensors = _ReadLinesAndParseSensorsAndLogEntries(reader);
            foreach (var sensor in sensors)
            {
                var brandingStrategy = _brandingStrategyDeterminer.DetermineBrandingStrategy(sensor.SensorType);
                sensor.EvaluateBranding(referenceValuesBySensorType[sensor.SensorType], brandingStrategy);
            }

            var jObject = new JObject();
            foreach (var sensor in sensors)
            {
                jObject.Add(sensor.Name, sensor.Branding);
            }

            return jObject.ToString();
        }

        private ICollection<Sensor> _ReadLinesAndParseSensorsAndLogEntries(TextReader reader)
        {
            var sensors = new List<Sensor>();
            Sensor currentSensor = default;

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var lineMeaning = _lineMeaningDetector.DetectLineMeaning(line);
                switch (lineMeaning)
                {
                    case LogLineMeaning.SensorIdentifier:
                        currentSensor = _sensorIdentifierParser.ParseSensorIdentifier(line);
                        sensors.Add(currentSensor);
                        break;
                    case LogLineMeaning.LogEntry:
                        if (currentSensor == default)
                        {
                            throw new ArgumentException("Missing sensor identifier line.");
                        }

                        var logEntry = _logEntryParser.ParseLogEntry(line);
                        currentSensor.AddLogEntry(logEntry);
                        break;
                    default:
                        throw new ArgumentException("Unknown line meaning.");
                }
            }

            return sensors;
        }
    }
}
