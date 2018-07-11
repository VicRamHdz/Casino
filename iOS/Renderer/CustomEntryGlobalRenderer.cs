using System;
using Cheeteye.iOS.Renderer;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryGlobalRenderer))]
namespace Cheeteye.iOS.Renderer
{
	public class CustomEntryGlobalRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.BorderStyle = UITextBorderStyle.None;

				var view = (Element as Entry);
				if (view != null)
				{
					view.SizeChanged += (obj, args) =>
					{
						var xamEl = obj as Entry;
						if (xamEl == null)
							return;

						// get native control (UITextField)
						var entry = this.Control;

						// Create borders (bottom only)
						CALayer border = new CALayer();
						float width = 1.0f;
						border.BorderColor = UIColor.White.CGColor;  // white border color
						border.Frame = new CGRect(x: 0, y: xamEl.Height - width, width: xamEl.Width, height: 1.0f);
						border.BorderWidth = width;

						entry.Layer.AddSublayer(border);

						entry.Layer.MasksToBounds = true;
						//entry.BorderStyle = UITextBorderStyle.None;
						//entry.BackgroundColor = new UIColor(1, 1, 1, 1); // white

						//increasing margin to fill border space
						//xamEl.Margin = new Thickness(0, 10, 0, 10);
					};
				}
			}
		}
	}
}
