using System;
using System.Collections.Generic;
using Cheeteye.ViewModels;
using Xamarin.Forms;

namespace Cheeteye.Views
{
    public partial class EventsContentView : ContentView
    {
        public EventsContentView()
        {
        }

        public EventsContentView(EventsContentViewModel ViewModel)
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}
