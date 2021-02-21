using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    public interface IBrandingStrategy
    {
        string EvaluateBranding(double referenceValue, IEnumerable<double> logValues);
    }
}