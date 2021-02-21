using System;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;

namespace Widgets365.QualityControl.BrandingStrategies
{
    public class ThermometerBrandingStrategy : IBrandingStrategy // todo: very precise is missing - add a test
    {
        public string EvaluateBranding(double referenceValue, IEnumerable<double> logValues)
        {
            var (mean, standardDeviation) = logValues.MeanStandardDeviation();
            if (Math.Abs(referenceValue - mean) <= 0.5 && standardDeviation <= 3) // todo: add unit tests for this
            {
                return "ultra precise";
            }
            return "precise";
        }
    }
}