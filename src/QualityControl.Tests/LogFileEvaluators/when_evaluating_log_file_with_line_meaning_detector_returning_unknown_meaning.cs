using System;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors;
using ThreeSixtyFiveWidgets.QualityControl.Tests.Builders;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_line_meaning_detector_returning_unknown_meaning
    {
        private LogFileEvaluator _logFileEvaluator;

        [SetUp]
        public void Context()
        {
            var lineMeaningDetector = A.Fake<ILineMeaningDetector>();
            A.CallTo(() => lineMeaningDetector.DetectLineMeaning(A<string>._)).Returns((LogLineMeaning)(-1));

            _logFileEvaluator = new LogFileEvaluatorBuilder()
                .WithLineMeaningDetector(lineMeaningDetector)
                .Build();
        }

        [Test]
        public void exception_is_thrown()
        {
            var exception = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFileFromString(
@"reference 70.0 45.0 6
thermometer temp-1
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe("Unknown line meaning.");
        }
    }
}