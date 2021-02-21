using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers
{
    internal interface IReferenceParser
    {
        IDictionary<SensorType, string> ParseReference(string? referenceLine);
    }
}