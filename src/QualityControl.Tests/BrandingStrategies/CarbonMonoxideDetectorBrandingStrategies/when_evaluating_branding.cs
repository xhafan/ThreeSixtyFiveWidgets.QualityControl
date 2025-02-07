﻿using System.Linq;
using NUnit.Framework;
using Shouldly;
using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;

namespace ThreeSixtyFiveWidgets.QualityControl.Tests.BrandingStrategies.CarbonMonoxideDetectorBrandingStrategies
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

        [TestCase(6, new[] { 3, 9 }, "keep", TestName = "{m}: 1 within 3 ppm")]
        [TestCase(6, new[] { 3, 10 }, "discard", TestName = "{m}: 2 too high value")]
        [TestCase(6, new[] { 2, 9 }, "discard", TestName = "{m}: 3 too low value")]
        public void branding_is_evaluated_correctly(int referenceValue, int[] logValues, string expectedBranding)
        {
            var branding = _brandingStrategy.EvaluateBranding($"{referenceValue}", logValues.Select(x => $"{x}"));

            branding.ShouldBe(expectedBranding);
        }
    }
}