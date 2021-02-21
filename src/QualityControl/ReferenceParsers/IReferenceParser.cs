using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers
{
    public interface IReferenceParser
    {
        IDictionary<SensorType, string> ParseReference(string referenceLine);
    }
}