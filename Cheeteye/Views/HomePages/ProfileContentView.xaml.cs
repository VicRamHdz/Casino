using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Cheeteye.ViewModels;

namespace Cheeteye.Views
{
    public partial class ProfileContentView : ContentView
    {
        public ProfileContentView()
        {
        }

        public ProfileContentView(ProfileContentViewModel ViewModel)
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}
