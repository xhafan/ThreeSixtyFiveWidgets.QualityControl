using System;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.BrandingStrategies.BrandingStrategyDeterminers
{
    [TestFixture]
    public class when_determining_branding_strategy_for_unknown_sensor_type
    {
        private BrandingStrategyDeterminer _determiner;

        [SetUp]
        public void Context()
        {
            _determiner = new BrandingStrategyDeterminer();
        }

        [Test]
        public void exception_is_thrown()
        {
            var ex = Should.Throw<ArgumentException>(() => _determiner.DetermineBrandingStrategy((SensorType) (-1)));

            ex.Message.ShouldBe("Unknown sensor type -1");
        }
    }
}