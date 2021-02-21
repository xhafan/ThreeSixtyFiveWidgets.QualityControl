using System;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.SensorEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_invalid_reading
    {
        private SensorEvaluator _sensorEvaluator;

        [SetUp]
        public void Context()
        {
            _sensorEvaluator = new SensorEvaluator();
        }

        [TestCase("2007-04 72.4", "Invalid log line.", 
            TestName = "{m}: 1 Invalid date")]
        [TestCase("2007-04-05T22:00 A", "Invalid value in reading.",
            TestName = "{m}: 2 Invalid value")]
        [TestCase("2007-04-05T22:00 72.4 23", "Too many entries in reading.",
            TestName = "{m}: 3 Too many entries")]
        public void exception_is_thrown(string readingLine, string expectedExceptionMessage)
        {
            var exception = Should.Throw<ArgumentException>(() => _sensorEvaluator.EvaluateLogFileFromString(
$@"reference 70.0 45.0 6
thermometer temp-1
{readingLine}"
                )
            );
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}