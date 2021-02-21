namespace Widgets365.QualityControl.SensorIdentifierParsers
{
    public interface ISensorIdentifierParser
    {
        Sensor ParseSensorIdentifier(string sensorIdentifierLine);
    }
}