namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    public interface IBrandingStrategyDeterminer
    {
        IBrandingStrategy DetermineBrandingStrategy(SensorType sensorType);
    }
}