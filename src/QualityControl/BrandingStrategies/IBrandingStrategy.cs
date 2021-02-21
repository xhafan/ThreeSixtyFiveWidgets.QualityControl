using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    public interface IBrandingStrategy
    {
        string EvaluateBranding(string referenceValue, IEnumerable<string> logValues);
    }
}