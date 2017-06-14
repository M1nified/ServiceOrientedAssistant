# Tips

## InstanceContextMode.PerSession

https://stackoverflow.com/a/4407405

In `WeatherService\App.config`

```xml
<endpoint address="" binding="wsHttpBinding" contract="NWeatherService.IWeatherService">
```

instead of

```xml
<endpoint address="" binding="httpHttpBinding" contract="NWeatherService.IWeatherService">
```