using System;
using System.Linq;
using Cheeteye.DependencyServices;
using Cheeteye.iOS.DependencyServices;
using EventKit;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CalendarInformation))]
namespace Cheeteye.iOS.DependencyServices
{
    public class CalendarInformation : ICalendarInformation
    {
        public string AddEvent(string Title, string Description, DateTime StartDate, DateTime EndDate, string StartTimeZone, string EndTimeZone)
        {
            try
            {
                EKEvent newEvent = EKEvent.FromStore(AppMain.Self.EventStore);
                // set the alarm for 10 minutes from now
                newEvent.AddAlarm(EKAlarm.FromDate(DateTimeToNSDate(StartDate.AddMinutes(10))));
                // make the event start 20 minutes from now and last 30 minutes
                newEvent.StartDate = DateTimeToNSDate(StartDate.AddMinutes(20));
                newEvent.EndDate = DateTimeToNSDate(EndDate.AddMinutes(50));
                newEvent.Title = Title;
                newEvent.Notes = Description;

                EKCalendar[] calendars = AppMain.Self.EventStore.GetCalendars(EKEntityType.Event);
                if (calendars.Length > 0)
                {
                    newEvent.Calendar = calendars.FirstOrDefault();
                }
                else
                {
                    newEvent.Calendar = AppMain.Self.EventStore.DefaultCalendarForNewEvents;
                }

                //saving the event
                NSError errorEvent;
                AppMain.Self.EventStore.SaveEvent(newEvent, EKSpan.ThisEvent, out errorEvent);

                if (errorEvent != null)
                    throw new Exception(errorEvent.ToString());


                return "event added: " + newEvent.CalendarItemIdentifier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private NSDate DateTimeToNSDate(DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
                date = DateTime.SpecifyKind(date, DateTimeKind.Local);
            return (NSDate)date;
        }
    }
}
