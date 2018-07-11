using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Cheeteye.Controls;
using Cheeteye.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomGradientButton), typeof(CustomGradientButtonRenderer))]
namespace Cheeteye.Droid.Renderer
{
    public class CustomGradientButtonRenderer : ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //var resources = Control.Context.Resources;
            //var metrics = resources.DisplayMetrics;
            //float dp = 5 * ((float)metrics.DensityDpi / (float)DisplayMetricsDensity.Default);

            var formsButton = Element as CustomGradientButton;
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(formsButton.BorderRadius);
            gradientDrawable.SetOrientation(GradientDrawable.Orientation.BottomTop);
            gradientDrawable.SetColors(new int[] { formsButton.EndColor.MultiplyAlpha(formsButton.AlphaMultiplier).ToAndroid().ToArgb(), formsButton.StartColor.MultiplyAlpha(formsButton.AlphaMultiplier).ToAndroid().ToArgb() });
            if (formsButton.HasBorder)
            {
                gradientDrawable.SetStroke((int)formsButton.BorderWidth, formsButton.BorderColor.ToAndroid());
            }

            if (Control != null)
            {
                Control.Background = gradientDrawable;
                Control.SetTextColor(formsButton.TextColor.ToAndroid());
            }
        }
    }
}
