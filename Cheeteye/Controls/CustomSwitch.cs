using System;
using Xamarin.Forms;

namespace Cheeteye.Controls
{
    public class CustomSwitch : Switch
    {
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(CustomSwitch), Color.Yellow, BindingMode.OneWay);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public static readonly BindableProperty InactiveColorProperty = BindableProperty.Create(nameof(InactiveColor), typeof(Color), typeof(CustomSwitch), Color.LightGray, BindingMode.OneWay);

        public Color InactiveColor
        {
            get { return (Color)GetValue(InactiveColorProperty); }
            set { SetValue(InactiveColorProperty, value); }
        }

    }
}
