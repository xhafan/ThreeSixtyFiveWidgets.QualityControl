using Widgets365.QualityControl.ReferenceParsers;

namespace Widgets365.QualityControl.Tests.Builders
{
    public class LogFileEvaluatorBuilder
    {
        private IReferenceParser _referenceParser;
        private ISensorIdentifierParser _sensorIdentifierParser;

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

        public LogFileEvaluator Build()
        {
            return new(
                _referenceParser ?? new ReferenceParser(),
                _sensorIdentifierParser ?? new SensorIdentifierParser()
            );
        }
    }
}