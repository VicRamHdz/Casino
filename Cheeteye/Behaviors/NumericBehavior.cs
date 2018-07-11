using System;
using Xamarin.Forms;

namespace Cheeteye.Behaviors
{
    public class NumericBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(NumericBehavior), default(int), BindingMode.OneWay);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == e.OldTextValue)
                return;

            var entry = (Entry)sender;

            double result;
            bool IsValid = double.TryParse((string.IsNullOrEmpty(e.NewTextValue) ? "0" : e.NewTextValue), out result);

            if (!IsValid)
            {
                entry.Text = e.OldTextValue;
            }

            // if Entry text is longer then valid length
            if (entry.Text?.Length > MaxLength)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 1); // remove last char

                entry.Text = entryText;
            }
        }
    }
}
