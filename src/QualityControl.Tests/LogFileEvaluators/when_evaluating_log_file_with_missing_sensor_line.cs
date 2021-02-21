using System;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.Tests.Builders;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_missing_sensor_line
    {
        private LogFileEvaluator _logFileEvaluator;

        [SetUp]
        public void Context()
        {
            _logFileEvaluator = new LogFileEvaluatorBuilder().Build();
        }

        [Test]
        public void exception_is_thrown()
        {
            var exception = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFile(
@"reference 70.0 45.0 6
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe("Missing sensor line.");
        }
    }
}