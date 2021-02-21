using System.Collections.Generic;

namespace Widgets365.QualityControl.ReferenceParsers
{
    public interface IReferenceParser
    {
        IDictionary<SensorType, double> ParseReference(string referenceLine);
    }
}