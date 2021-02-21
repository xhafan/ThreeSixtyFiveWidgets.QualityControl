using System;
using System.IO;

namespace Widgets365.QualityControl
{
    public class LogFileEvaluator : ILogFileEvaluator
    {
        public string EvaluateLogFile(string logContentsStr)
        {
            using (var reader = new StringReader(logContentsStr))
            {
                var referenceLine = reader.ReadLine();
                if (referenceLine == null || !referenceLine.StartsWith("reference "))
                {
                    throw new ArgumentException("Reference line is missing.");
                }
                var referenceLineSplit = referenceLine.Split(' ');
                if (referenceLineSplit.Length != 4)
                {
                    throw new ArgumentException("Reference values are invalid.");
                }

                double referenceTemperature;
                if (!double.TryParse(referenceLineSplit[1], out referenceTemperature))
                {
                    throw new ArgumentException("Reference temperature value is invalid.");
                }

                double referenceRelativeHumidity;
                if (!double.TryParse(referenceLineSplit[2], out referenceRelativeHumidity))
                {
                    throw new ArgumentException("Reference relative humidity value is invalid.");
                }

                int referenceCarbonMonoxidePpm;
                if (!int.TryParse(referenceLineSplit[3], out referenceCarbonMonoxidePpm))
                {
                    throw new ArgumentException("Reference carbon monoxide ppm value is invalid.");
                }

                // while ((line = reader.ReadLine()) != null)
                // {
                //     
                // }
            }

            return null;
        }
    }
}
