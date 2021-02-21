# ThreeSixtyFiveWidgets.QualityControl

Usage: 

```c#
SensorEvaluator.EvaluateLogFile(
@"reference 70.0 45.0 6
thermometer temp-1
2007-04-05T22:00 72.4
2007-04-05T22:01 76.0
thermometer temp-2
2007-04-05T22:01 69.5
2007-04-05T22:02 70.1
humidity hum-1
2007-04-05T22:04 45.2
2007-04-05T22:05 45.3
humidity hum-2
2007-04-05T22:04 44.4
2007-04-05T22:05 43.9
monoxide mon-1
2007-04-05T22:04 5
2007-04-05T22:05 7
monoxide mon-2
2007-04-05T22:04 2
2007-04-05T22:05 4
");
```

```c#
SensorEvaluator.EvaluateLogFile(File.OpenRead("logfile.txt"));

```