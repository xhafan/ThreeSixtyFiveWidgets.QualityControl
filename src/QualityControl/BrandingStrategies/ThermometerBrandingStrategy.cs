using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    internal class ThermometerBrandingStrategy : IBrandingStrategy
    {
        public string EvaluateBranding(string referenceValue, IEnumerable<string> logValues)
        {
            if (!double.TryParse(referenceValue, out var referenceTemperature))
            {
                throw new ArgumentException("Reference temperature value is invalid.");
            }

            var logValuesAsDoubles = logValues.Select(logValue =>
            {
                if (!double.TryParse(logValue, out var value))
                {
                    throw new ArgumentException("Invalid value in reading.");
                }
                return value;
            });

            var (mean, standardDeviation) = logValuesAsDoubles.MeanStandardDeviation();
            if (Math.Abs(referenceTemperature - mean) <= 0.5 && standardDeviation < 3)
            {
                return "ultra precise";
            }
            if (Math.Abs(referenceTemperature - mean) <= 0.5 && standardDeviation < 5)
            {
                return "very precise";
            }
            return "precise";
        }
    }
}