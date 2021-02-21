namespace ThreeSixtyFiveWidgets.QualityControl.LineMeaningDetectors
{
    internal interface ILineMeaningDetector
    {
        LogLineMeaning DetectLineMeaning(string line);
    }
}