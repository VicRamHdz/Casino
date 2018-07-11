using System;
using Cheeteye.Controls;
using Cheeteye.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Cheeteye.iOS.Renderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
                SetTextAlignment(e.NewElement as CustomPicker);
            }
        }

        private void SetTextAlignment(CustomPicker picker)
        {
            if (picker == null)
                return;

            if (picker.TextAlignment == PickerTextAlignment.Left)
                Control.TextAlignment = UITextAlignment.Left;
            if (picker.TextAlignment == PickerTextAlignment.Center)
                Control.TextAlignment = UITextAlignment.Center;
            if (picker.TextAlignment == PickerTextAlignment.Right)
                Control.TextAlignment = UITextAlignment.Right;
            if (picker.TextAlignment == PickerTextAlignment.Justified)
                Control.TextAlignment = UITextAlignment.Justified;
            if (picker.TextAlignment == PickerTextAlignment.Natural)
                Control.TextAlignment = UITextAlignment.Natural;
        }
    }
}
