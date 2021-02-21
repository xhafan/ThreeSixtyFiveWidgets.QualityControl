using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    internal interface IBrandingStrategy
    {
        string EvaluateBranding(string referenceValue, IEnumerable<string> logValues);
    }
}