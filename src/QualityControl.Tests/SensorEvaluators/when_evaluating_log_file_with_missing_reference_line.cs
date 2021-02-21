using System;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.SensorEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_missing_reference_line
    {
        private SensorEvaluator _sensorEvaluator;

        [SetUp]
        public void Context()
        {
            _sensorEvaluator = new SensorEvaluator();
        }

        [Test]
        public void exception_is_thrown()
        {
            var exception = Should.Throw<ArgumentException>(() => _sensorEvaluator.EvaluateLogFileFromString(
@"thermometer temp-1
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe("Reference line is missing.");
        }
    }
}