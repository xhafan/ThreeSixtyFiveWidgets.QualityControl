namespace Widgets365.QualityControl.SensorIdentifierParsers
{
    public interface ISensorIdentifierParser
    {
        (SensorType SensorType, string Name) ParseSensorIdentifier(string sensorIdentifierLine);
    }
}