﻿using System;
using System.Globalization;
using System.Linq;

namespace Widgets365.QualityControl.LineMeaningDetectors
{
    public class LineMeaningDetector : ILineMeaningDetector
    {
        public LogLineMeaning DetectLineMeaning(string line)
        {
            if (SensorConstants.SensorIdentifiers.Any(sensorIdentifier => line.StartsWith($"{sensorIdentifier} ")))
            {
                return LogLineMeaning.SensorIdentifier;
            }
            var lineSplit = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (lineSplit.Length > 0 
                && DateTime.TryParseExact(lineSplit[0], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return LogLineMeaning.LogEntry;
            }
            throw new ArgumentException("Invalid log line.");
        }
    }
}