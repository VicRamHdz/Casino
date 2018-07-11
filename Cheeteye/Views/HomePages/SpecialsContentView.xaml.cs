using System;
using System.Collections.Generic;
using Cheeteye.ViewModels;
using Xamarin.Forms;

namespace Cheeteye.Views
{
    public partial class SpecialsContentView : ContentView
    {
        public SpecialsContentView()
        {
        }

        public SpecialsContentView(SpecialsContentViewModel ViewModel)
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}
