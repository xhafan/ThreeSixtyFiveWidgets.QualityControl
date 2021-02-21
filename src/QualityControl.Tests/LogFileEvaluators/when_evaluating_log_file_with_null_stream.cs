using System;
using System.IO;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.Tests.Builders;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_null_stream
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
            var ex = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFile((Stream)null));

            ex.Message.ShouldBe("Log stream is null.");
        }
    }
}