using System;

namespace NTimeService
{
    public class TimeService : ITimeService
    {
        public string GetCurrentTime()
        {
            return string.Format("Aktualny czas to {0}", DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
