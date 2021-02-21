namespace Widgets365.QualityControl.ReferenceParsers
{
    public interface ISensorIdentifierParser
    {
        (SensorType SensorType, string Name) ParseSensorIdentifier(string sensorIdentifierLine);
    }
}