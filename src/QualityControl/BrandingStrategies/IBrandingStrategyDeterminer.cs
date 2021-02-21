namespace Widgets365.QualityControl.BrandingStrategies
{
    public interface IBrandingStrategyDeterminer
    {
        IBrandingStrategy DetermineBrandingStrategy(SensorType sensorType);
    }
}