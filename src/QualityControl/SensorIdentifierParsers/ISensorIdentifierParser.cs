namespace ThreeSixtyFiveWidgets.QualityControl.SensorIdentifierParsers
{
    public interface ISensorIdentifierParser
    {
        Sensor ParseSensorIdentifier(string sensorIdentifierLine);
    }
}