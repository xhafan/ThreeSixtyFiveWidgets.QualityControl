﻿using NUnit.Framework;
using Shouldly;
using Widgets365.QualityControl.Tests.Builders;

namespace Widgets365.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    [Ignore("Test is failing as the code has not been implemented yet")]
    public class when_evaluating_log_file
    {
        private string _output;

        [SetUp]
        public void Context()
        {
            var logFileEvaluator = new LogFileEvaluatorBuilder().Build();


            _output = logFileEvaluator.EvaluateLogFile(
@"reference 70.0 45.0 6
thermometer temp-1
2007-04-05T22:00 72.4
2007-04-05T22:01 76.0
2007-04-05T22:02 79.1
2007-04-05T22:03 75.6
2007-04-05T22:04 71.2
2007-04-05T22:05 71.4
2007-04-05T22:06 69.2
2007-04-05T22:07 65.2
2007-04-05T22:08 62.8
2007-04-05T22:09 61.4
2007-04-05T22:10 64.0
2007-04-05T22:11 67.5
2007-04-05T22:12 69.4
thermometer temp-2
2007-04-05T22:01 69.5
2007-04-05T22:02 70.1
2007-04-05T22:03 71.3
2007-04-05T22:04 71.5
2007-04-05T22:05 69.8
humidity hum-1
2007-04-05T22:04 45.2
2007-04-05T22:05 45.3
2007-04-05T22:06 45.1
humidity hum-2
2007-04-05T22:04 44.4
2007-04-05T22:05 43.9
2007-04-05T22:06 44.9
2007-04-05T22:07 43.8
2007-04-05T22:08 42.1
monoxide mon-1
2007-04-05T22:04 5
2007-04-05T22:05 7
2007-04-05T22:06 9
monoxide mon-2
2007-04-05T22:04 2
2007-04-05T22:05 4
2007-04-05T22:06 10
2007-04-05T22:07 8
2007-04-05T22:08 6
");
        }

        [Test]
        public void output_is_correct()
        {
            _output.ShouldBe(
@"{
""temp-1"": ""precise"",
""temp-2"": ""ultra precise"",
""hum-1"": ""keep"",
""hum-2"": ""discard"",
""mon-1"": ""keep"",
""mon-2"": ""discard""
}"
            );
        }
    }
}