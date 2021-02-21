using System;

namespace Widgets365.QualityControl.BrandingStrategies
{
    public class BrandingStrategyDeterminer : IBrandingStrategyDeterminer
    {
        public IBrandingStrategy DetermineBrandingStrategy(SensorType sensorType)
        {
            switch (sensorType)
            {
                case SensorType.Thermometer:
                    return new ThermometerBrandingStrategy();
                case SensorType.HumiditySensor:
                    return new HumiditySensorBrandingStrategy();
                case SensorType.CarbonMonoxideDetector:
                    return new CarbonMonoxideDetectorBrandingStrategy();
                default:
                    throw new ArgumentException($"Unknown sensor type {sensorType}"); // todo: not tested
            }
        }
    }
}