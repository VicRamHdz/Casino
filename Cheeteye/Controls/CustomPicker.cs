using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Cheeteye.Controls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(PickerTextAlignment), typeof(CustomPicker), PickerTextAlignment.Left, BindingMode.OneWay);

        public PickerTextAlignment TextAlignment
        {
            get { return (PickerTextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        public static readonly BindableProperty SetFocusProperty = BindableProperty.Create(nameof(SetFocus), typeof(bool), typeof(CustomPicker), default(bool), BindingMode.TwoWay);

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

    public enum PickerTextAlignment
    {
        Left = 0,
        Center = 1,
        Right = 2,
        Justified = 3,
        Natural = 4,
    }
}
