using System;
using Xamarin.Forms;

namespace Cheeteye.Effects
{
    public class ShadowEffect : RoutingEffect
    {
        public double Radius { get; set; }

        public Color Color { get; set; }

        public double DistanceX { get; set; }

        public double DistanceY { get; set; }

        public ShadowEffect() : base("Cheeteye.LabelShadowEffect")
        {
        }
    }
}
