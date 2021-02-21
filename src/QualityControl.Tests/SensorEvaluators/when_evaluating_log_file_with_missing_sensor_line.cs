using System;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.SensorEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_missing_sensor_line
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
@"reference 70.0 45.0 6
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe("Missing sensor line.");
        }
    }
}