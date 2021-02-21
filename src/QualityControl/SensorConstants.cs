using System.Collections.Generic;

namespace ThreeSixtyFiveWidgets.QualityControl
{
    public static class SensorConstants
    {
        public static IDictionary<string, SensorType> SensorTypeBySensorIdentifier =
            new Dictionary<string, SensorType>
            {
                {"thermometer", SensorType.Thermometer},
                {"humidity", SensorType.HumiditySensor},
                {"monoxide", SensorType.CarbonMonoxideDetector}
            };

        public static IEnumerable<string> SensorIdentifiers = SensorTypeBySensorIdentifier.Keys;
    }
}