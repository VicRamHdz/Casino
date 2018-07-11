using System;
namespace Cheeteye.Models
{
    public class MembershipModel : BaseModel
    {
        private string _MembershipNumber;
        public string MembershipNumber
        {
            get { return _MembershipNumber; }
            set { SetProperty(ref _MembershipNumber, value); }
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

        private string _Pin;
        public string Pin
        {
            get { return _Pin; }
            set
            {
                SetProperty(ref _Pin, value);
                SetPin();
            }
        }

        private void SetPin()
        {
            CodeOne = !string.IsNullOrEmpty(Pin) ? Pin.Substring(0, 1) : string.Empty;
            CodeTwo = !string.IsNullOrEmpty(Pin) ? Pin.Substring(1, 1) : string.Empty;
            CodeThree = !string.IsNullOrEmpty(Pin) ? Pin.Substring(2, 1) : string.Empty;
            CodeFour = !string.IsNullOrEmpty(Pin) ? Pin.Substring(3, 1) : string.Empty;
        }

        private string _CodeOne;
        public string CodeOne
        {
            get { return _CodeOne; }
            set { SetProperty(ref _CodeOne, value); }
        }

        private string _CodeTwo;
        public string CodeTwo
        {
            get { return _CodeTwo; }
            set { SetProperty(ref _CodeTwo, value); }
        }

        private string _CodeThree;
        public string CodeThree
        {
            get { return _CodeThree; }
            set { SetProperty(ref _CodeThree, value); }
        }

        private string _CodeFour;
        public string CodeFour
        {
            get { return _CodeFour; }
            set { SetProperty(ref _CodeFour, value); }
        }
    }
}
