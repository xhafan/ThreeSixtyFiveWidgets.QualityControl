using Widgets365.QualityControl.BrandingStrategies;
using Widgets365.QualityControl.LineMeaningDetectors;
using Widgets365.QualityControl.LogEntryParsers;
using Widgets365.QualityControl.ReferenceParsers;
using Widgets365.QualityControl.SensorIdentifierParsers;

namespace Widgets365.QualityControl.Tests.Builders
{
    public class LogFileEvaluatorBuilder
    {
        private IReferenceParser _referenceParser;
        private ISensorIdentifierParser _sensorIdentifierParser;
        private ILineMeaningDetector _lineMeaningDetector;
        private ILogEntryParser _logEntryParser;
        private IBrandingStrategyDeterminer _brandingStrategyDeterminer;

        public LogFileEvaluatorBuilder WithReferenceParser(IReferenceParser referenceParser)
        {
            _referenceParser = referenceParser;
            return this;
        }

        public LogFileEvaluatorBuilder WithSensorIdentifierParser(ISensorIdentifierParser sensorIdentifierParser)
        {
            _sensorIdentifierParser = sensorIdentifierParser;
            return this;
        }

        public LogFileEvaluatorBuilder WithLineMeaningDetector(ILineMeaningDetector lineMeaningDetector)
        {
            _lineMeaningDetector = lineMeaningDetector;
            return this;
        }

        public LogFileEvaluatorBuilder WithLogEntryParser(ILogEntryParser logEntryParser)
        {
            _logEntryParser = logEntryParser;
            return this;
        }

        public LogFileEvaluatorBuilder WithBrandingStrategyDeterminer(IBrandingStrategyDeterminer brandingStrategyDeterminer)
        {
            _brandingStrategyDeterminer = brandingStrategyDeterminer;
            return this;
        }

        public LogFileEvaluator Build()
        {
            return new(
                _referenceParser ?? new ReferenceParser(),
                _sensorIdentifierParser ?? new SensorIdentifierParser(),
                _lineMeaningDetector ?? new LineMeaningDetector(),
                _logEntryParser ?? new LogEntryParser(),
                _brandingStrategyDeterminer ?? new BrandingStrategyDeterminer()
            );
        }
    }
}