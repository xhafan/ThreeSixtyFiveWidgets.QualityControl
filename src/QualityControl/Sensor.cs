using System.Collections.Generic;
using System.Linq;
using Widgets365.QualityControl.BrandingStrategies;

namespace Widgets365.QualityControl
{
    public class Sensor
    {
        private readonly List<LogEntry> _logEntries = new();

        public Sensor(SensorType sensorType, string name)
        {
            SensorType = sensorType;
            Name = name;
        }

        public SensorType SensorType { get; }
        public string Name { get; }
        public string Branding { get; private set; }

        public void AddLogEntry(LogEntry logEntry)
        {
            _logEntries.Add(logEntry);
        }

        public void EvaluateBranding(double referenceValue, IBrandingStrategy brandingStrategy)
        {
            Branding = brandingStrategy.EvaluateBranding(referenceValue, _logEntries.Select(x => x.Value));
        }
    }
}