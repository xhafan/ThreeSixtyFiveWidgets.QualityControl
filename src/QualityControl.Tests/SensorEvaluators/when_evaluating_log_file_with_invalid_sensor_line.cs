using System;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.SensorEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_invalid_sensor_line
    {
        private SensorEvaluator _sensorEvaluator;

        [SetUp]
        public void Context()
        {
            _sensorEvaluator = new SensorEvaluator();
        }

        [TestCase("noise temp-1", "Invalid log line.",
            TestName = "{m}: 1 Invalid sensor identifier")]
        [TestCase("", "Invalid log line.",
            TestName = "{m}: 2 Empty line")]
        [TestCase("thermometer temp-1 extra-data", "Sensor line is invalid.",
            TestName = "{m}: 3 Extra data in sensor line")]
        public void exception_is_thrown(string sensorLine, string expectedExceptionMessage)
        {
            var exception = Should.Throw<ArgumentException>(() => _sensorEvaluator.EvaluateLogFileFromString(
$@"reference 70.0 45.0 6
{sensorLine}
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}