namespace Widgets365.QualityControl.LineMeaningDetectors
{
    public interface ILineMeaningDetector
    {
        LogLineMeaning DetectLineMeaning(string line);
    }
}