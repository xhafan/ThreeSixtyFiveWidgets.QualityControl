namespace ThreeSixtyFiveWidgets.QualityControl.ReadingParsers
{
    internal interface IReadingParser
    {
        Reading ParseReading(string readingLine);
    }
}