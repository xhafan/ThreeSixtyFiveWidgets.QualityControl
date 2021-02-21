using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers
{
    public interface IReferenceParser
    {
        IDictionary<SensorType, double> ParseReference(string referenceLine);
    }
}