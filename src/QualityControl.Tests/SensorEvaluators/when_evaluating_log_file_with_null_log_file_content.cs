using System;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.SensorEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_null_log_file_content
    {
        private SensorEvaluator _sensorEvaluator;

        [SetUp]
        public void Context()
        {
            _sensorEvaluator = new SensorEvaluator();
        }

        [TestCase(null, TestName = "{m}: 1 null")]
        [TestCase("", TestName = "{m}: 2 empty string")]
        [TestCase(" ", TestName = "{m}: 3 whitespace")]
        public void exception_is_thrown(string logFileContent)
        {
            var ex = Should.Throw<ArgumentException>(() => _sensorEvaluator.EvaluateLogFileFromString(logFileContent));

            ex.Message.ShouldBe("Log file content is empty.");
        }
    }
}