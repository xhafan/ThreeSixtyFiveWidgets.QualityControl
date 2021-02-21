using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    internal class HumiditySensorBrandingStrategy : IBrandingStrategy
    {
        public string EvaluateBranding(string referenceValue, IEnumerable<string> logValues)
        {
            if (!double.TryParse(referenceValue, out var referenceRelativeHumidity))
            {
                throw new ArgumentException("Reference relative humidity value is invalid.");
            }

            var logValuesAsDoubles = logValues.Select(logValue =>
            {
                if (!double.TryParse(logValue, out var value))
                {
                    throw new ArgumentException("Invalid value in reading.");
                }
                return value;
            });

            foreach (var logValue in logValuesAsDoubles)
            {
                if (Math.Abs(logValue - referenceRelativeHumidity) > 1)
                {
                    return "discard";
                }
            }
            return "keep";
        }
    }
}