using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.SensorEvaluators
{
    [TestFixture]
    public class when_evaluating_log_file_with_null_stream
    {
        private SensorEvaluator _sensorEvaluator;

        [SetUp]
        public void Context()
        {
            _sensorEvaluator = new SensorEvaluator();
        }

        [Test]
        public void exception_is_thrown()
        {
            var ex = Should.Throw<ArgumentException>(() => _sensorEvaluator.EvaluateLogFileFromStream((Stream)null));

            ex.Message.ShouldBe("Log stream is null.");
        }
    }
}