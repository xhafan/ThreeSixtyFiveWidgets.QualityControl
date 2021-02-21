﻿using System;
using NUnit.Framework;
using Shouldly;
using Widgets365.QualityControl.Tests.Builders;

namespace Widgets365.QualityControl.Tests.LogFileEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_missing_reference_line
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
@"thermometer temp-1
2007-04-05T22:00 72.4"
                )
            );
            exception.Message.ShouldBe("Reference line is missing.");
        }
    }
}