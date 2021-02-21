using System;

namespace ThreeSixtyFiveWidgets.QualityControl.SensorParsers
{
    internal class SensorParser : ISensorParser
    {
        public Sensor ParseSensor(string sensorLine)
        {
            if (string.IsNullOrWhiteSpace(sensorLine))
            {
                throw new ArgumentException("Sensor line is missing.");
            }
            var sensorLineSplit = sensorLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (sensorLineSplit.Length != 2)
            {
                throw new ArgumentException("Sensor line is invalid.");
            }

            var sensorIdentifier = sensorLineSplit[0];
            if (!SensorConstants.SensorTypeBySensorIdentifier.ContainsKey(sensorIdentifier))
            {
                throw new ArgumentException("Invalid sensor identifier.");
            }

            return new(SensorConstants.SensorTypeBySensorIdentifier[sensorIdentifier], sensorLineSplit[1]);
        }
    }
}