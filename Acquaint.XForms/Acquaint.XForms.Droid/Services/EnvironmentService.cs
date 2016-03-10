using Android.OS;
using Acquaint.XForms.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (EnvironmentService))]

namespace Acquaint.XForms.Droid
{
    public class EnvironmentService : IEnvironmentService
    {
        #region IEnvironmentService implementation
        public bool IsRealDevice
        {
            get
            {
                string f = Build.Fingerprint;
                return !(f.Contains("vbox") || f.Contains("generic") || f.Contains("vsemu"));
            }
        }
        #endregion
    }
}

