using System;
namespace Cheeteye.Models
{
    public class UserProfileInfoModel : BaseModel
    {
        private string _MembershipNumber;
        public string MembershipNumber
        {
            get { return _MembershipNumber; }
            set { SetProperty(ref _MembershipNumber, value); }
        }

        private string _UserProfileId;
        public string UserProfileId
        {
            get { return _UserProfileId; }
            set { SetProperty(ref _UserProfileId, value); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetProperty(ref _FirstName, value); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set { SetProperty(ref _Mobile, value); }
        }

        private string _LanguageId;
        public string LanguageId
        {
            get { return _LanguageId; }
            set { SetProperty(ref _LanguageId, value); }
        }

        private string _TimeZoneId;
        public string TimeZoneId
        {
            get { return _TimeZoneId; }
            set { SetProperty(ref _TimeZoneId, value); }
        }
    }
}
