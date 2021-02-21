using System;

namespace Widgets365.QualityControl
{
    public record LogEntry(DateTime LoggedOn, double Value)
    {
        public DateTime LoggedOn { get; } = LoggedOn;
        public double Value { get; } = Value;
    }
}