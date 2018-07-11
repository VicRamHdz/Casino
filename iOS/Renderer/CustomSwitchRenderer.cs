using System;
using System.ComponentModel;
using Cheeteye.Controls;
using Cheeteye.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace Cheeteye.iOS.Renderer
{
    public class CustomSwitchRenderer : ViewRenderer<CustomSwitch, UISwitch>
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
                SetNativeControl(new UISwitch());
                Control.On = e.NewElement.IsToggled;
                Control.ValueChanged += ControlValueChanged;
                SetTintColor(Element.TintColor.ToUIColor());
                Element.Toggled += ElementToggled;
            }
        }

        #region Protected Methods

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "TintColor")
            {
                SetTintColor(Element.TintColor.ToUIColor());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.ValueChanged -= ControlValueChanged;
                Element.Toggled -= ElementToggled;
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Private Methods

        private void SetTintColor(UIColor color)
        {
            Control.TintColor = color;
            Control.OnTintColor = color;
        }

        private void ElementToggled(object sender, ToggledEventArgs e)
        {
            Control.SetState(Element.IsToggled, true);
        }

        private void ControlValueChanged(object sender, EventArgs e)
        {
            Element.IsToggled = Control.On;
        }

        #endregion
    }
}
