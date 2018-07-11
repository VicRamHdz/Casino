using System;
using System.Collections.Generic;
using Cheeteye.ViewModels;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace Cheeteye.Views
{
    public partial class ChallengesContentView : ContentView
    {
        public ChallengesContentView()
        {
        }

        public ChallengesContentView(ChallengesContentViewModel ViewModel)
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}
