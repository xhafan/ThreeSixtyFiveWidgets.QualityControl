using System;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_invalid_reference_values
    {
        private LogFileEvaluator _logFileEvaluator;

        [SetUp]
        public void Context()
        {
            _logFileEvaluator = new LogFileEvaluator();
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
        [TestCase("70.0 45.0 C", "Reference carbon monoxide ppm value is not an integer.", 
            TestName = "{m}: 6 Reference carbon monoxide ppm value not a number")]
        [TestCase("70.0 45.0 6.0", "Reference carbon monoxide ppm value is not an integer.",
            TestName = "{m}: 7 Reference carbon monoxide ppm value not an integer")]
        public void exception_is_thrown(string referenceValues, string expectedExceptionMessage)
        {
            var exception = Should.Throw<ArgumentException>(() => _logFileEvaluator.EvaluateLogFileFromString(
$@"reference {referenceValues}
thermometer temp-1
2007-04-05T22:00 72.4
humidity hum-1
2007-04-05T22:04 45.2
monoxide mon-1
2007-04-05T22:04 5"
                )
            );
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}