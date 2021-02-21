using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    public class CarbonMonoxideDetectorBrandingStrategy : IBrandingStrategy
    {
        public string EvaluateBranding(string referenceValue, IEnumerable<string> logValues)
        {
            if (!int.TryParse(referenceValue, out var referenceCarbonMonoxidePpm))
            {
                throw new ArgumentException("Reference carbon monoxide ppm value is not an integer.");
            }

            var logValuesAsInts = logValues.Select(logValue =>
            {
                if (!int.TryParse(logValue, out var value))
                {
                    throw new ArgumentException("Invalid value in reading.");
                }
                return value;
            });

            foreach (var logValue in logValuesAsInts)
            {
                if (Math.Abs(logValue - referenceCarbonMonoxidePpm) > 3)
                {
                    return "discard";
                }
            }
            return "keep";
        }
    }
}