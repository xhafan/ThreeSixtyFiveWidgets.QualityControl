using System;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.Tests.Builders;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_null_log_file_content
    {
        private LogFileEvaluator _logFileEvaluator;

        [SetUp]
        public void Context()
        {
            _logFileEvaluator = new LogFileEvaluatorBuilder().Build();
        }

        [TestCase(null, TestName = "{m}: 1 null")]
        [TestCase("", TestName = "{m}: 2 empty string")]
        [TestCase(" ", TestName = "{m}: 3 whitespace")]
        public void exception_is_thrown(string logFileContent)
        {
            var ex = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFile(logFileContent));

            ex.Message.ShouldBe("Log file content is empty.");
        }
    }
}