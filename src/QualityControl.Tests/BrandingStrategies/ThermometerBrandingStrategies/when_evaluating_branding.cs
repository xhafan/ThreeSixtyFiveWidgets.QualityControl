using System.Linq;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.BrandingStrategies.ThermometerBrandingStrategies
{
    [TestFixture]
    public class when_evaluating_branding
    {
        private ThermometerBrandingStrategy _brandingStrategy;

        [SetUp]
        public void Context()
        {
            _brandingStrategy = new ThermometerBrandingStrategy();
        }

        [TestCase(70, new[] { 72.9, 70.0, 67.1 }, "ultra precise", TestName = "{m}: 1 ultra precise")]
        [TestCase(70, new[] { 73.0, 70.0, 67.0 }, "very precise", TestName = "{m}: 2 very precise edge one")]
        [TestCase(70, new[] { 74.9, 70.0, 65.1 }, "very precise", TestName = "{m}: 3 very precise edge two")]
        [TestCase(70, new[] { 75.0, 70.0, 65.0 }, "precise", TestName = "{m}: 4 precise")]
        public void branding_is_evaluated_correctly(double referenceValue, double[] logValues, string expectedBranding)
        {
            var branding = _brandingStrategy.EvaluateBranding($"{referenceValue}", logValues.Select(x => $"{x}"));

            branding.ShouldBe(expectedBranding);
        }
    }
}