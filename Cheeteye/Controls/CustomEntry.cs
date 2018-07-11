using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Cheeteye.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty SetFocusProperty = BindableProperty.Create(nameof(SetFocus), typeof(bool), typeof(CustomEntry), default(bool), BindingMode.TwoWay);

        public bool SetFocus
        {
            get { return (bool)GetValue(SetFocusProperty); }
            set { SetValue(SetFocusProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == SetFocusProperty.PropertyName)
            {
                if (SetFocus)
                {
                    Focus();
                    SetFocus = false;
                }
            }
        }
    }
}
