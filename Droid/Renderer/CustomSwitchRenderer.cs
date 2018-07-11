using System;
using System.ComponentModel;
using Android.Graphics;
using Cheeteye.Controls;
using Cheeteye.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace Cheeteye.Droid.Renderer
{
    public class CustomSwitchRenderer : ViewRenderer<CustomSwitch, Android.Widget.Switch>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomSwitch> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                e.OldElement.Toggled -= ElementToggled;
            }

            if (e.NewElement != null)
            {
                SetNativeControl(new Android.Widget.Switch(Context));
                Control.Checked = e.NewElement.IsToggled;
                Control.CheckedChange += ControlValueChanged;
                SetTintColor(Element.TintColor.ToAndroid());
                Element.Toggled += ElementToggled;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsToggled")
            {
                SetTintColor(Element.TintColor.ToAndroid());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.CheckedChange -= ControlValueChanged;
                Element.Toggled -= ElementToggled;
            }

            base.Dispose(disposing);
        }

        #region Private Methods

        private void SetTintColor(Android.Graphics.Color color)
        {
            if (Control == null || Element == null)
            {
                return;
            }

            if (Control.Checked)
            {
                Control.ThumbDrawable.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
                Control.TrackDrawable.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
            }
            else
            {
                Control.ThumbDrawable.SetColorFilter(Element.InactiveColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                Control.TrackDrawable.SetColorFilter(Element.InactiveColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }

        private void ElementToggled(object sender, ToggledEventArgs e)
        {
            Control.Checked = Element.IsToggled;
            SetTintColor(Element.TintColor.ToAndroid());
        }

        private void ControlValueChanged(object sender, EventArgs e)
        {
            Element.IsToggled = Control.Checked;
            SetTintColor(Element.TintColor.ToAndroid());
        }

        #endregion
    }
}
