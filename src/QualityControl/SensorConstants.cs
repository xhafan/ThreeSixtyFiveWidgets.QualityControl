using System.Collections.Generic;

namespace Widgets365.QualityControl
{
    public static class SensorConstants
    {
        public static IDictionary<string, SensorType> SensorTypeByLogSensorIdentifier =
            new Dictionary<string, SensorType>
            {
                {"thermometer", SensorType.Thermometer},
                {"humidity", SensorType.HumiditySensor},
                {"monoxide", SensorType.CarbonMonoxideDetector}
            };

        public static IEnumerable<string> SensorIdentifiers = SensorTypeByLogSensorIdentifier.Keys;
    }
}