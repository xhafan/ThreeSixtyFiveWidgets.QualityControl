using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;
using ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors;
using ThreeSixtyFiveWidgets.QualityControl.ReadingParsers;
using ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers;
using ThreeSixtyFiveWidgets.QualityControl.SensorParsers;

namespace ThreeSixtyFiveWidgets.QualityControl
{
    /// <summary>
    /// Evaluates a log file with sensor readings.
    /// </summary>
    public class SensorEvaluator
    {
        private readonly IReferenceParser _referenceParser;
        private readonly ISensorParser _sensorParser;
        private readonly ILineMeaningDetector _lineMeaningDetector;
        private readonly IReadingParser _readingParser;
        private readonly IBrandingStrategyDeterminer _brandingStrategyDeterminer;

        internal SensorEvaluator(
            IReferenceParser referenceParser,
            ISensorParser sensorParser,
            ILineMeaningDetector lineMeaningDetector,
            IReadingParser readingParser,
            IBrandingStrategyDeterminer brandingStrategyDeterminer
            )
        {
            _referenceParser = referenceParser;
            _sensorParser = sensorParser;
            _lineMeaningDetector = lineMeaningDetector;
            _readingParser = readingParser;
            _brandingStrategyDeterminer = brandingStrategyDeterminer;
        }

        internal SensorEvaluator()
            : this(
                new ReferenceParser(),
                new SensorParser(),
                new LineMeaningDetector(),
                new ReadingParser(),
                new BrandingStrategyDeterminer()
            )
        {
        }

        /// <summary>
        /// Evaluates a log file with sensor readings provided in a string.
        /// </summary>
        /// <param name="logContentsStr">Log file content</param>
        /// <returns>Evaluation output in json format, keys are sensor names, values are evaluated branding.</returns>
        public static string EvaluateLogFile(string logContentsStr)
        {
            return new SensorEvaluator().EvaluateLogFileFromString(logContentsStr);
        }

        internal string EvaluateLogFileFromString(string logContentsStr)
        {
            if (string.IsNullOrWhiteSpace(logContentsStr))
            {
                throw new ArgumentException("Log file content is empty.");
            }
            return EvaluateLogFileFromStream(new MemoryStream(Encoding.UTF8.GetBytes(logContentsStr)));
        }

        internal string EvaluateLogFileFromStream(Stream logStream)
        {
            if (logStream == null)
            {
                throw new ArgumentException("Log stream is null.");
            }
            using var reader = new StreamReader(logStream);
            var referenceLine = reader.ReadLine();
            var referenceValuesBySensorType = _referenceParser.ParseReference(referenceLine);

            var sensors = _ReadLinesAndParseSensorsAndReadings(reader);
            foreach (var sensor in sensors)
            {
                var brandingStrategy = _brandingStrategyDeterminer.DetermineBrandingStrategy(sensor.SensorType);
                sensor.EvaluateBranding(referenceValuesBySensorType[sensor.SensorType], brandingStrategy);
            }

            return _GenerateOutput(sensors);
        }

        private string _GenerateOutput(IEnumerable<Sensor> sensors)
        {
            var jObject = new JObject();
            foreach (var sensor in sensors)
            {
                jObject.Add(sensor.Name, sensor.Branding);
            }

            return jObject.ToString();
        }

        private ICollection<Sensor> _ReadLinesAndParseSensorsAndReadings(TextReader reader)
        {
            var sensors = new List<Sensor>();
            Sensor? currentSensor = default;

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var lineMeaning = _lineMeaningDetector.DetectLineMeaning(line);
                switch (lineMeaning)
                {
                    case LogLineMeaning.Sensor:
                        currentSensor = _sensorParser.ParseSensor(line);
                        sensors.Add(currentSensor);
                        break;
                    case LogLineMeaning.Reading:
                        if (currentSensor == default)
                        {
                            throw new ArgumentException("Missing sensor line.");
                        }

                        var reading = _readingParser.ParseReading(line);
                        currentSensor.AddReading(reading);
                        break;
                    default:
                        throw new ArgumentException("Unknown line meaning.");
                }
            }

            return sensors;
        }
    }
}
