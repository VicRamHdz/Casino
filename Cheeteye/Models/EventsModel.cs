using System;
using System.Globalization;

namespace Cheeteye.Models
{
    public class EventsModel : BaseModel
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Duration;
        public string Duration
        {
            get { return _Duration; }
            set { SetProperty(ref _Duration, value); }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { SetProperty(ref _Date, value); }
        }

        public string Day
        {
            get { return Date.Day < 9 ? $"0{Date.Day}" : Date.Day.ToString(); }
        }

        public string Month
        {
            get { return Date.ToString("MMM", CultureInfo.InvariantCulture); }
        }

        public string DateHour
        {
            get { return $"{Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)}, {Duration}"; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set { SetProperty(ref _Subject, value); }
        }

        private string _BannerUrl;
        public string BannerUrl
        {
            get { return _BannerUrl; }
            set { SetProperty(ref _BannerUrl, value); }
        }
    }
}
