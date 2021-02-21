using System;
using System.Globalization;

namespace ThreeSixtyFiveWidgets.QualityControl.ReadingParsers
{
    public class ReadingParser : IReadingParser
    {
        public Reading ParseReading(string readingLine)
        {
            var readingLineSplit = readingLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (readingLineSplit.Length > 2)
            {
                throw new ArgumentException("Too many entries in reading.");
            }
            var loggedOn = DateTime.ParseExact(readingLineSplit[0], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            return new Reading(loggedOn, readingLineSplit[1]);
        }
    }
}