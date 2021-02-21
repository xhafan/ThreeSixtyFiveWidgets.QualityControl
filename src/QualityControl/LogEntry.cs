using System;

namespace ThreeSixtyFiveWidgets.QualityControl
{
    public record LogEntry(DateTime LoggedOn, double Value)
    {
        public DateTime LoggedOn { get; } = LoggedOn;
        public double Value { get; } = Value;
    }
}