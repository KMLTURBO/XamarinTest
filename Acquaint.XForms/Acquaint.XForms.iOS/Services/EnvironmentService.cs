using ObjCRuntime;
using Acquaint.XForms.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (EnvironmentService))]

namespace Acquaint.XForms.iOS
{
    public class EnvironmentService : IEnvironmentService
    {
        #region IEnvironmentService implementation
        public bool IsRealDevice => Runtime.Arch == Arch.DEVICE;

        #endregion
    }
}

