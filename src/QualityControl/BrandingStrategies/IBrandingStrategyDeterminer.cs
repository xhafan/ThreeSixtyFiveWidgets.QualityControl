namespace ThreeSixtyFiveWidgets.QualityControl.BrandingStrategies
{
    internal interface IBrandingStrategyDeterminer
    {
        IBrandingStrategy DetermineBrandingStrategy(SensorType sensorType);
    }
}