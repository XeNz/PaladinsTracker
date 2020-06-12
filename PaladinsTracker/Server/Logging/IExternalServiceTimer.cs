using System;

namespace PaladinsTracker.Server.Logging
{
    public interface IExternalServiceTimer
    {
        void AddTimeSpan(TimeSpan timeSpent);
        TimeSpan Calculate();
    }
}