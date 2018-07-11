using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cheeteye.Helpers
{
    public class LabelValueFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = new FormattedString();
            if (parameter.ToString().Contains("BEGIN|"))
            {
                s.Spans.Add(new Span() { Text = parameter.ToString().Replace("BEGIN|", string.Empty) });
            }
            if (value != null)
            {
                s.Spans.Add(new Span
                {
                    Text = value.ToString(),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 16d
                });
            }
            if (parameter.ToString().Contains("END|"))
            {
                s.Spans.Add(new Span() { Text = parameter.ToString().Replace("END|", string.Empty) });
            }
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((FormattedString)value).Spans.ToString();
        }
    }
}
