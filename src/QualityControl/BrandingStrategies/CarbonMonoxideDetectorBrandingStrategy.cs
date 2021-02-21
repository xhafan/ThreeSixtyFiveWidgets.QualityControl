using System;
using System.Collections.Generic;

namespace Widgets365.QualityControl.BrandingStrategies
{
    public class CarbonMonoxideDetectorBrandingStrategy : IBrandingStrategy
    {
        public string EvaluateBranding(double referenceValue, IEnumerable<double> logValues)
        {
            foreach (var logValue in logValues)
            {
                if (Math.Abs(logValue - referenceValue) > 3)
                {
                    return "discard";
                }
            }
            return "keep";
        }
    }
}