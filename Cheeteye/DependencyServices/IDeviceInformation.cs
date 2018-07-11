using System;
using Cheeteye.Models;

namespace Cheeteye.DependencyServices
{
    public interface IDeviceInformation
    {
        string GetPhoneNumber();
        string GetModel();
        string GetLanguage();
        string GetDisplay();
        string GetSimId();
        string GetOSVersion();
        string GetIPAddress();
        GeoLocationModel GetGeoLocation(bool IncludeHeading = false);
        string GetDeviceId();
        bool GetIsEmulator();
        bool GetIsCompromised();
        string GetApplicationKey();
        string GetApplicationVersionNumber();
        void ExecuteLocationManager(bool IncludeHeading = false);
        string GetApplicationName();
    }
}
