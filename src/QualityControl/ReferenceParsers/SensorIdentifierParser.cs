using System;

namespace Widgets365.QualityControl.ReferenceParsers
{
    public class SensorIdentifierParser : ISensorIdentifierParser
    {
        public (SensorType SensorType, string Name) ParseSensorIdentifier(string sensorIdentifierLine)
        {
            if (string.IsNullOrWhiteSpace(sensorIdentifierLine))
            {
                throw new ArgumentException("Sensor identifier line is missing.");
            }
            var sensorIdentifierLineSplit = sensorIdentifierLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (sensorIdentifierLineSplit.Length != 2)
            {
                throw new ArgumentException("Sensor identifier line is invalid.");
            }

            var sensorIdentifier = sensorIdentifierLineSplit[0];
            if (!SensorConstants.SensorTypeByLogSensorIdentifier.ContainsKey(sensorIdentifier))
            {
                throw new ArgumentException("Invalid sensor identifier.");
            }

            return (SensorConstants.SensorTypeByLogSensorIdentifier[sensorIdentifier], sensorIdentifierLineSplit[1]);
        }
    }
}