using System;
using EventKit;
using Foundation;
using UIKit;

namespace Cheeteye.iOS
{
    [Register("AppMain")]
    public class AppMain : UIApplication
    {
        public EKEventStore EventStore
        {
            get { return eventStore; }
        }

        protected EKEventStore eventStore;

        public static AppMain Self { get; private set; }

        public AppMain(IntPtr p) : base(p)
        {
            Self = this;
            eventStore = new EKEventStore();
        }
    }
}
