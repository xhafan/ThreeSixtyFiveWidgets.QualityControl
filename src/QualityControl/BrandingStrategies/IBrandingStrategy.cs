using System.Collections.Generic;

namespace Widgets365.QualityControl.BrandingStrategies
{
    public interface IBrandingStrategy
    {
        string EvaluateBranding(double referenceValue, IEnumerable<double> logValues);
    }
}