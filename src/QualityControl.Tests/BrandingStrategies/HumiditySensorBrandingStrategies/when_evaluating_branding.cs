using NUnit.Framework;
using Shouldly;
using Widgets365.QualityControl.BrandingStrategies;

namespace Widgets365.QualityControl.Tests.BrandingStrategies.HumiditySensorBrandingStrategies
{
    [TestFixture]
    public class when_evaluating_branding
    {
        private HumiditySensorBrandingStrategy _brandingStrategy;

        [SetUp]
        public void Context()
        {
            _brandingStrategy = new HumiditySensorBrandingStrategy();
        }

        [TestCase(45.0, new[] { 46.0, 44.0 }, "keep", TestName = "{m}: 1 within 1 percent")]
        [TestCase(45.0, new[] { 46.1, 44.0 }, "discard", TestName = "{m}: 2 too high value")]
        [TestCase(45.0, new[] { 46.0, 43.9 }, "discard", TestName = "{m}: 3 too low value")]
        public void branding_is_evaluated_correctly(double referenceValue, double[] logValues, string expectedBranding)
        {
            var branding = _brandingStrategy.EvaluateBranding(referenceValue, logValues);

            branding.ShouldBe(expectedBranding);
        }
    }
}