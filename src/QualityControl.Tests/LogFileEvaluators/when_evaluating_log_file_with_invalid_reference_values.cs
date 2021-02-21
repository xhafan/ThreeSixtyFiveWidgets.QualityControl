using System;
using NUnit.Framework;
using Shouldly;
using Widgets365.QualityControl.Tests.Builders;

namespace Widgets365.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_invalid_reference_values
    {
        private LogFileEvaluator _logFileEvaluator;

        [SetUp]
        public void Context()
        {
            _logFileEvaluator = new LogFileEvaluatorBuilder().Build();
        }

        [TestCase("70.0 45.0", "Reference values are invalid.", 
            TestName = "{m}: 1 Missing carbon monoxide value")]
        [TestCase("70.0 45.0 6 65", "Reference values are invalid.", 
            TestName = "{m}: 2 Extra unknown value")]
        [TestCase("", "Reference values are invalid.", 
            TestName = "{m}: 3 No reference values")]
        [TestCase("A 45.0 6", "Reference temperature value is invalid.", 
            TestName = "{m}: 4 Reference temperature value not a number")]
        [TestCase("70.0 B 6", "Reference relative humidity value is invalid.", 
            TestName = "{m}: 5 Reference relative humidity value not a number")]
        [TestCase("70.0 45.0 C", "Reference carbon monoxide ppm value is invalid.", 
            TestName = "{m}: 6 Reference carbon monoxide ppm value not a number")]
        public void exception_is_thrown(string referenceValues, string expectedExceptionMessage)
        {
            var exception = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFile(
$@"reference {referenceValues}
thermometer temp-1
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}