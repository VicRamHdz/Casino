using System;
using Android.Content;
using Android.Database;
using Android.Provider;
using Cheeteye.DependencyServices;
using Cheeteye.Droid.DependencyServices;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(CalendarInformation))]
namespace Cheeteye.Droid.DependencyServices
{
    public class CalendarInformation : ICalendarInformation
    {
        public string AddEvent(string Title, string Description, DateTime StartDate, DateTime EndDate, string StartTimeZone, string EndTimeZone)
        {
            //Getting available calendars
            var calendarsUri = CalendarContract.Calendars.ContentUri;

            string[] calendarsProjection = {
                CalendarContract.Calendars.InterfaceConsts.Id,
                CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
                CalendarContract.Calendars.InterfaceConsts.AccountName
            };

            var loader = new CursorLoader(Forms.Context, calendarsUri, calendarsProjection, null, null, null);
            var cursor = (ICursor)loader.LoadInBackground();

            if (!cursor.MoveToFirst())
            {
                return "You don't have any calendar";
            }

            int calId = cursor.GetInt(cursor.GetColumnIndex(calendarsProjection[0]));


            ContentValues eventValues = new ContentValues();

            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId,
                            calId);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
                            Title);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
                            Description);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
                            GetDateTimeMS(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, StartDate.Minute));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
                            GetDateTimeMS(EndDate.Year, EndDate.Month, EndDate.Day, EndDate.Hour, EndDate.Minute));

            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
                            StartTimeZone);//UTC
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
                            EndTimeZone);//UTC

            var uri = Forms.Context.ContentResolver.Insert(CalendarContract.Events.ContentUri,
            eventValues);

            return "event added";
        }


        long GetDateTimeMS(int yr, int month, int day, int hr, int min)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Java.Util.CalendarField.DayOfMonth, day);
            c.Set(Java.Util.CalendarField.HourOfDay, hr);
            c.Set(Java.Util.CalendarField.Minute, min);
            c.Set(Java.Util.CalendarField.Month, month);
            c.Set(Java.Util.CalendarField.Year, yr);

            return c.TimeInMillis;
        }
    }
}
