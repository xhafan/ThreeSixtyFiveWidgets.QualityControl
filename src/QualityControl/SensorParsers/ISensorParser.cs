namespace ThreeSixtyFiveWidgets.QualityControl.SensorParsers
{
    public interface ISensorParser
    {
        Sensor ParseSensor(string sensorLine);
    }
}