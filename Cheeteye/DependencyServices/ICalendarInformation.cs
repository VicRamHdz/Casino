using System;
namespace Cheeteye.DependencyServices
{
    public interface ICalendarInformation
    {
        string AddEvent(string Title, string Description, DateTime StartDate, DateTime EndDate, string StartTimeZone, string EndTimeZone);
    }
}
