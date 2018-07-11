using System;
using System.Collections.Generic;
using Cheeteye.ViewModels;
using Xamarin.Forms;

namespace Cheeteye.Views
{
    public partial class RewardsContentView : ContentView
    {
        public RewardsContentView()
        {
            InitializeComponent();
        }
        public RewardsContentView(RewardsContentViewModel ViewModel)
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}
