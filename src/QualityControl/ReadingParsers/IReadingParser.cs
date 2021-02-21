namespace ThreeSixtyFiveWidgets.QualityControl.ReadingParsers
{
    public interface IReadingParser
    {
        Reading ParseReading(string readingLine);
    }
}