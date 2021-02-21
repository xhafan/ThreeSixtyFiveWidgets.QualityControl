using System;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.Tests.Builders;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_invalid_sensor_identifier_line
    {
        private LogFileEvaluator _logFileEvaluator;

        [SetUp]
        public void Context()
        {
            _logFileEvaluator = new LogFileEvaluatorBuilder().Build();
        }

        [TestCase("noise temp-1", "Invalid log line.",
            TestName = "{m}: 1 Invalid sensor identifier")]
        [TestCase("", "Invalid log line.",
            TestName = "{m}: 2 Empty line")]
        [TestCase("thermometer temp-1 extra-data", "Sensor identifier line is invalid.",
            TestName = "{m}: 3 Extra data in sensor identifier line")]
        public void exception_is_thrown(string sensorIdentifierLine, string expectedExceptionMessage)
        {
            var exception = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFile(
$@"reference 70.0 45.0 6
{sensorIdentifierLine}
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}