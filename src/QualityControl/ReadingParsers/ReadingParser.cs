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
            var dateTime = DateTime.ParseExact(readingLineSplit[0], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            return new Reading(dateTime, readingLineSplit[1]);
        }
    }
}