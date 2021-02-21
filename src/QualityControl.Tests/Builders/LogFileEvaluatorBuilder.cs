using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;
using ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors;
using ThreeSixtyFiveWidgets.QualityControl.ReadingParsers;
using ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers;
using ThreeSixtyFiveWidgets.QualityControl.SensorParsers;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.Builders
{
    public class LogFileEvaluatorBuilder
    {
        private IReferenceParser _referenceParser;
        private ISensorParser _sensorParser;
        private ILineMeaningDetector _lineMeaningDetector;
        private IReadingParser _readingParser;
        private IBrandingStrategyDeterminer _brandingStrategyDeterminer;

        internal LogFileEvaluatorBuilder WithReferenceParser(IReferenceParser referenceParser)
        {
            _referenceParser = referenceParser;
            return this;
        }

        internal LogFileEvaluatorBuilder WithSensorParser(ISensorParser sensorParser)
        {
            _sensorParser = sensorParser;
            return this;
        }

        internal LogFileEvaluatorBuilder WithLineMeaningDetector(ILineMeaningDetector lineMeaningDetector)
        {
            _lineMeaningDetector = lineMeaningDetector;
            return this;
        }

        internal LogFileEvaluatorBuilder WithReadingParser(IReadingParser readingParser)
        {
            _readingParser = readingParser;
            return this;
        }

        internal LogFileEvaluatorBuilder WithBrandingStrategyDeterminer(IBrandingStrategyDeterminer brandingStrategyDeterminer)
        {
            _brandingStrategyDeterminer = brandingStrategyDeterminer;
            return this;
        }

        public LogFileEvaluator Build()
        {
            return new(
                _referenceParser ?? new ReferenceParser(),
                _sensorParser ?? new SensorParser(),
                _lineMeaningDetector ?? new LineMeaningDetector(),
                _readingParser ?? new ReadingParser(),
                _brandingStrategyDeterminer ?? new BrandingStrategyDeterminer()
            );
        }
    }
}