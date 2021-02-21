namespace ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors
{
    public interface ILineMeaningDetector
    {
        LogLineMeaning DetectLineMeaning(string line);
    }
}