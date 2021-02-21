using System;
using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl.ReferenceParsers
{
    internal class ReferenceParser : IReferenceParser
    {
        public IDictionary<SensorType, string> ParseReference(string? referenceLine)
        {
            if (string.IsNullOrWhiteSpace(referenceLine) || !referenceLine.StartsWith("reference "))
            {
                throw new ArgumentException("Reference line is missing.");
            }
            var referenceLineSplit = referenceLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (referenceLineSplit.Length != 4)
            {
                throw new ArgumentException("Reference values are invalid.");
            }
            
            return new Dictionary<SensorType, string>
            {
                {SensorType.Thermometer, referenceLineSplit[1]},
                {SensorType.HumiditySensor, referenceLineSplit[2]},
                {SensorType.CarbonMonoxideDetector, referenceLineSplit[3]},
            };
        }
    }
}