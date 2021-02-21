namespace ThreeSixtyFiveWidgets.QualityControl.SensorParsers
{
    internal interface ISensorParser
    {
        Sensor ParseSensor(string sensorLine);
    }
}