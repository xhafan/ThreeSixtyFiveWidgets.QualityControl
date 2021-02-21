using System;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;

namespace Widgets365.QualityControl.BrandingStrategies
{
    public class ThermometerBrandingStrategy : IBrandingStrategy
    {
        public string EvaluateBranding(double referenceValue, IEnumerable<double> logValues)
        {
            var (mean, standardDeviation) = logValues.MeanStandardDeviation();
            if (Math.Abs(referenceValue - mean) <= 0.5 && standardDeviation <= 3)
            {
                return "ultra precise";
            }
            if (Math.Abs(referenceValue - mean) <= 0.5 && standardDeviation <= 5)
            {
                return "very precise";
            }
            return "precise";
        }
    }
}