using System;
using System.Collections.Generic;

namespace Widgets365.QualityControl.ReferenceParsers
{
    public class ReferenceParser : IReferenceParser
    {
        public IDictionary<SensorType, double> ParseReference(string referenceLine)
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

            if (!double.TryParse(referenceLineSplit[1], out var referenceTemperature))
            {
                throw new ArgumentException("Reference temperature value is invalid.");
            }

            if (!double.TryParse(referenceLineSplit[2], out var referenceRelativeHumidity))
            {
                throw new ArgumentException("Reference relative humidity value is invalid.");
            }

            if (!double.TryParse(referenceLineSplit[3], out var referenceCarbonMonoxidePpm))
            {
                throw new ArgumentException("Reference carbon monoxide ppm value is invalid.");
            }

            return new Dictionary<SensorType, double>
            {
                {SensorType.Thermometer, referenceTemperature},
                {SensorType.HumiditySensor, referenceRelativeHumidity},
                {SensorType.CarbonMonoxideDetector, referenceCarbonMonoxidePpm},
            };
        }
    }
}