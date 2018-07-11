using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Android.Support.V4.View;
using Cheeteye.Controls;
using Cheeteye.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace Cheeteye.Droid.Renderer
{
    public class CustomFrameRenderer : VisualElementRenderer<CustomFrame>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomFrame> e)
        {
            base.OnElementChanged(e);
            ApplyStyle();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            //if (e.PropertyName == "CornerRadius" || e.PropertyName == "StrokeThickness"
            //   || e.PropertyName == "OutlineColor" || e.PropertyName == "BackgroundColor"
            //    || e.PropertyName == "StartColor" || e.PropertyName == "EndColor")
            //{
            ApplyStyle();
            //}
        }

        private void ApplyStyle()
        {
            var frame = Element as CustomFrame;

            var gradientDrawable = new GradientDrawable();

            gradientDrawable.SetCornerRadius(frame.CornerRadius);
            gradientDrawable.SetOrientation(GradientDrawable.Orientation.BottomTop);
            gradientDrawable.SetColors(new int[] { frame.EndColor.MultiplyAlpha(frame.AlphaMultiplier).ToAndroid().ToArgb(),
                frame.StartColor.MultiplyAlpha(frame.AlphaMultiplier).ToAndroid().ToArgb() });
            if (frame.HasBorder)
            {
                gradientDrawable.SetStroke((int)frame.StrokeThickness, frame.OutlineColor.ToAndroid());
            }

            var ld = default(LayerDrawable);
            if (frame.HasShadow)
            {
                var shadow = new GradientDrawable();

                int[] colors1 = { frame.ShadowColor.MultiplyAlpha(frame.AlphaMultiplier).ToAndroid().ToArgb(),
                Color.Transparent.ToAndroid().ToArgb()
                };
                shadow.SetOrientation(GradientDrawable.Orientation.TopBottom);
                //shadow.SetColors(colors1);
                shadow.SetStroke((int)frame.StrokeThickness + 5, frame.ShadowColor.ToAndroid());
                shadow.SetCornerRadius(frame.CornerRadius);

                ld = new LayerDrawable(new Drawable[] { shadow, gradientDrawable });

                ld.SetLayerInset(0, 0, 0, 0, 0);
                ld.SetLayerInset(1, 0, 6, 0, 0);
            }
            else
            {
                ld = new LayerDrawable(new Drawable[] { gradientDrawable });
                ld.SetLayerInset(0, 0, 0, 0, 0);
            }

            Background = ld;
        }
    }
}
