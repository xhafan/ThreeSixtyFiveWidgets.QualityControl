using NUnit.Framework;
using Shouldly;
using Widgets365.QualityControl.BrandingStrategies;

namespace Widgets365.QualityControl.Tests.BrandingStrategies.CarbonMonoxideDetectorBrandingStrategies
{
    [TestFixture]
    public class when_evaluating_branding
    {
        private CarbonMonoxideDetectorBrandingStrategy _brandingStrategy;

        [SetUp]
        public void Context()
        {
            _brandingStrategy = new CarbonMonoxideDetectorBrandingStrategy();
        }

        [TestCase(6, new[] { 3.0, 9.0 }, "keep", TestName = "{m}: 1 within 3 ppm")]
        [TestCase(6, new[] { 3.0, 10.0 }, "discard", TestName = "{m}: 2 too high value")]
        [TestCase(6, new[] { 2.0, 9.0 }, "discard", TestName = "{m}: 3 too low value")]
        public void branding_is_evaluated_correctly(double referenceValue, double[] logValues, string expectedBranding)
        {
            var branding = _brandingStrategy.EvaluateBranding(referenceValue, logValues);

            branding.ShouldBe(expectedBranding);
        }
    }
}