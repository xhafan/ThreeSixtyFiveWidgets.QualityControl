using System;
using System.Globalization;
using System.Linq;

namespace ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors
{
    public class LineMeaningDetector : ILineMeaningDetector
    {
        public LogLineMeaning DetectLineMeaning(string line)
        {
            if (SensorConstants.SensorIdentifiers.Any(sensorIdentifier => line.StartsWith($"{sensorIdentifier} ")))
            {
                return LogLineMeaning.Sensor;
            }
            var lineSplit = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (lineSplit.Length > 0 
                && DateTime.TryParseExact(lineSplit[0], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return LogLineMeaning.Reading;
            }
            throw new ArgumentException("Invalid log line.");
        }
    }
}