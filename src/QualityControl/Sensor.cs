using System.Collections.Generic;
using System.Linq;
using ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies;

namespace ThreeSixtyFiveWidgets.QualityControl
{
    internal class Sensor
    {
        private readonly List<Reading> _readings = new();

        public Sensor(SensorType sensorType, string name)
        {
            SensorType = sensorType;
            Name = name;
        }

        public SensorType SensorType { get; }
        public string Name { get; }
        public string? Branding { get; private set; }

        public void AddReading(Reading reading)
        {
            _readings.Add(reading);
        }

        public void EvaluateBranding(string referenceValue, IBrandingStrategy brandingStrategy)
        {
            Branding = brandingStrategy.EvaluateBranding(referenceValue, _readings.Select(x => x.Value));
        }
    }
}